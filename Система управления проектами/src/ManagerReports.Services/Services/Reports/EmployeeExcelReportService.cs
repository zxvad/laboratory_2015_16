using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ManagerReports.Services.Interfaces.Reports;
using ManagerReports.Services.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ManagerReports.Services.Services.Reports
{
    public class EmployeeExcelReportService : IEmployeeExcelReportService
    {
        private readonly IEmployeeReportService _employeeReportService;

        public EmployeeExcelReportService(IEmployeeReportService employeeReportService)
        {
            _employeeReportService = employeeReportService;
        }

        public byte[] GetExcelReport(DateTime? beginDate, DateTime? endDate)
        {
            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("Отчет по сотрудникам");

                CreateTitles(ws);
                CreateEmployeesReportBody(ws, _employeeReportService.GetAllReports(beginDate, endDate));
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

        private static void CreateTotalResult<T>(ExcelWorksheet worksheet, T value, int rowIndex, int columnIndex, ExcelHorizontalAlignment alignmnet = ExcelHorizontalAlignment.Right)
        {
            worksheet.Cells[rowIndex, columnIndex].Style.Font.Bold = true;
            worksheet.Cells[rowIndex, columnIndex].Style.HorizontalAlignment = alignmnet;
            worksheet.Cells[rowIndex, columnIndex].Value = value;
        }

        private static void CreateEmployeesReportBody(ExcelWorksheet worksheet, IEnumerable<EmployeeReport> employeesReport)
        {
            CreateTitles(worksheet);

            var rowIndex = 2;

            foreach (var employeeReport in employeesReport.Where(i => i.ProjectResources.Any()))
            {
                CreateSectionTitle(worksheet, employeeReport.Employee.FullName, ref rowIndex);
                //строка для валюты
                foreach (var projectResource in employeeReport.ProjectResources.OrderBy(i => i.ProjectName).ThenBy(i => i.Resource.Name))
                {
                    worksheet.Cells[rowIndex, 1].Value = projectResource.ProjectName;
                    worksheet.Cells[rowIndex, 2].Value = projectResource.Resource.Name;
                    worksheet.Cells[rowIndex, 3].Value = projectResource.Resource.TakenTime;
                    worksheet.Cells[rowIndex, 4].Value = projectResource.Resource.Rate;
                    worksheet.Cells[rowIndex, 5].Value = projectResource.Resource.TakenMoney;

                    rowIndex++;
                }

                CreateTotalResult(worksheet, employeeReport.TakenTime, rowIndex, 3);
                CreateTotalResult(worksheet, employeeReport.TakenMoney, rowIndex, 5);

                rowIndex++;
            }

        }

        private static void AutoFitColumns(ExcelWorksheet worksheet)
        {
            for (var i = 1; i < 6; i++)
            {
                worksheet.Column(i).AutoFit();
            }
        }
    }
}