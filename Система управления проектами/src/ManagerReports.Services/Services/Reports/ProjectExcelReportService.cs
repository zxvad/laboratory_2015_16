using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ManagerReports.Dal;
using ManagerReports.Services.Interfaces.Reports;
using ManagerReports.Services.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ManagerReports.Services.Services.Reports
{
    public class ProjectExcelReportService : IProjectExcelReportService
    {
        private readonly IProjectReportService _projectReportService;

        public ProjectExcelReportService(IProjectReportService projectReportService)
        {
            _projectReportService = projectReportService;
        }

        public byte[] GetExcelReport(DateTime? beginDate, DateTime? endDate)
        {
            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("Отчет по проектам");

                CreateTitles(ws);
                CreateProjectsReportBody(ws, _projectReportService.GetAllReports(beginDate, endDate));
                AutoFitColumns(ws);

                return package.GetAsByteArray();
            }
        }

        private static void CreateTitles(ExcelWorksheet worksheet)
        {
            worksheet.Row(1).Style.Font.Bold = true;
            worksheet.Cells[1, 1, 1, 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells[1, 1, 1, 5].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#dff0d8"));
            worksheet.Cells[1, 1].Value = "Проект";
            worksheet.Cells[1, 2].Value = "Ресурс";
            worksheet.Cells[1, 3].Value = "Время";
            worksheet.Cells[1, 4].Value = "Рейт";
            worksheet.Cells[1, 5].Value = "Стоимость";
        }

        private static void CreateProjectsReportBody(ExcelWorksheet worksheet, IEnumerable<ProjectReport> projectsReport)
        {
            var rowIndex = 2;
            foreach (var project in projectsReport.ToArray())
            {
                CreateResources(worksheet, project.Project.Name, project.Resources.Where(i => i.EmployeesTimeMonies.Any()).ToArray(), project.EmployeesWithoutResource.ToArray(), ref rowIndex);

                foreach (var projectVersion in project.ProjectVerisons)
                {
                    CreateResources(worksheet, projectVersion.Name, projectVersion.Resources.Where(i => i.EmployeesTimeMonies.Any()).ToArray(), projectVersion.EmployeesWithoutResource.ToArray(), ref rowIndex);
                }

                CreateTotalResult(worksheet, "Итого", rowIndex, 1, ExcelHorizontalAlignment.Left);
                CreateTotalResult(worksheet, project.Project.TakenTime, rowIndex, 3);
                CreateTotalResult(worksheet, project.Project.TakenMoney, rowIndex, 5);

                rowIndex++;
            }
        }

        private static void CreateResources(ExcelWorksheet worksheet, string name, Resource[] resources, EmployeeTimeMoney[] employeesWithoutResource, ref int rowIndex)
        {
            CreateSectionTitle(worksheet, name, ref rowIndex);
            foreach (var resource in resources)
            {
                CreateEmployees(worksheet, resource.EmployeesTimeMonies, resource.Name, resource.Rate, ref rowIndex);
            }

            if (employeesWithoutResource.Any())
            {
                CreateEmployees(worksheet, employeesWithoutResource, "Не задан", decimal.Zero, ref rowIndex);
            }
        }

        private static void CreateTotalResult<T>(ExcelWorksheet worksheet, T value, int rowIndex, int columnIndex, ExcelHorizontalAlignment alignmnet = ExcelHorizontalAlignment.Right)
        {
            worksheet.Cells[rowIndex, columnIndex].Style.Font.Bold = true;
            worksheet.Cells[rowIndex, columnIndex].Style.HorizontalAlignment = alignmnet;
            worksheet.Cells[rowIndex, columnIndex].Value = value;
        }

        private static void CreateEmployees(ExcelWorksheet worksheet, IEnumerable<EmployeeTimeMoney> employees, string resourceName, decimal resourceRate, ref int rowIndex)
        {
            foreach (var employeeInfo in employees.Where(i => i.TakenTime != 0).OrderBy(i => i.EmployeeFullName))
            {
                worksheet.Cells[rowIndex, 1].Value = employeeInfo.EmployeeFullName;
                worksheet.Cells[rowIndex, 2].Value = resourceName;
                worksheet.Cells[rowIndex, 3].Value = employeeInfo.TakenTime;
                worksheet.Cells[rowIndex, 4].Value = resourceRate;
                worksheet.Cells[rowIndex, 5].Value = employeeInfo.TakenMoney;

                rowIndex++;
            }
        }

        private static void CreateSectionTitle(ExcelWorksheet worksheet, string sectionName, ref int rowIndex)
        {
            worksheet.Row(rowIndex).Style.Font.Bold = true;
            worksheet.Row(rowIndex).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            worksheet.Cells[rowIndex, 1, rowIndex, 5].Merge = true;
            worksheet.Cells[rowIndex, 1, rowIndex, 5].Value = sectionName;
            worksheet.Cells[rowIndex, 1, rowIndex, 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells[rowIndex, 1, rowIndex, 5].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#f5f5f5"));

            ++rowIndex;
        }

        private static void AutoFitColumns(ExcelWorksheet worksheet)
        {
            for (var i = 1; i < 6; i++)
            {
                worksheet.Column(i).AutoFit();
            }
        }

        private static void CreateCurrencySign(ExcelWorksheet worksheet, int rowIndex, CurrencyTypes currency)
        {
            worksheet.Cells[rowIndex, 1, rowIndex, 5].Merge = true;
            worksheet.Cells[rowIndex, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            worksheet.Cells[rowIndex, 1].Value = GetCurrencyStringValue(currency);
            worksheet.Row(rowIndex).Style.Font.Bold = true;
        }

        private static string GetCurrencyStringValue(CurrencyTypes currency)
        {
            switch (currency)
            {
                case CurrencyTypes.Roubles:
                    return "\x20bd";
                case CurrencyTypes.Dollars:
                    return "\x0024";
                case CurrencyTypes.Pounds:
                    return "\x00a3";
            }

            return "";
        }
    }
}