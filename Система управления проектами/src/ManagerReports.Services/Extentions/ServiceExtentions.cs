using System;
using System.Collections.Generic;
using ManagerReports.Dal.Entities;
using ManagerReports.Services.Models;
using System.Linq;

namespace ManagerReports.Services.Extentions
{
    internal static class ServiceExtentions
    {
        public static PaymentRecord ToPaymentRecord(this PaymentRecordEntity source)
        {
            return new PaymentRecord
            {
                Id = source.Id,
                Date = source.Date,
                Amount = source.Amount,
                ProjectVersionId = source.ProjectVersionId
            };
        }

        public static TimeRecord ToTimeRecord(this TimeRecordEntity source)
        {
            return new TimeRecord
            {
                Id = source.Id,
                EmployeeFullName = source.Employee.FullName,
                ProjectName = source.Issue.Project.Name,
                ProjectVersionName = source.Issue.ProjectVersion?.Name,
                ResourceNames = source.Resources.Select(i => i.Resource.Name).ToArray(),
                Activity = source.Activity,
                Comments = source.Comments,
                Date = source.Date,
                Hours = source.Hours,
                IssueId = source.Issue.ExternalId
            };
        }

        public static Resource ToResourceModel(this SoldResourceEntity source, DateTime? beginDate = null, DateTime? endDate = null)
        {
            var actualBeginDate = beginDate ?? DateTime.MinValue;
            var actualEndDate = endDate ?? DateTime.MaxValue;

            var resourceModel = new Resource
            {
                Id = source.Id,
                Name = source.Name,
                SoldHours = source.Hours,
                Rate = source.Rate,
                EmployeesTimeMonies = source.Employees.Select(i =>
                {
                    var employeeInfo = new EmployeeTimeMoney
                    {
                        EmployeeFullName = i.Employee.FullName,

                        TakenTime = i.Employee.TimeRecords.Where(timeRecord =>
                        {
                            if (timeRecord.Resources.Count != 1)
                            {
                                return false;
                            }

                            if (!(actualBeginDate <= timeRecord.Date && timeRecord.Date <= actualEndDate))
                            {
                                return false;
                            }

                            return timeRecord.Resources.First().Resource.Name == source.Name;
                        })
                            .Sum(timeRecord => timeRecord.Hours)
                    };

                    employeeInfo.TakenMoney = employeeInfo.TakenTime * source.Rate;

                    return employeeInfo;
                })
            };

            resourceModel.TakenTime = resourceModel.EmployeesTimeMonies.Sum(i => i.TakenTime);
            resourceModel.TakenMoney = resourceModel.TakenTime * resourceModel.Rate;

            return resourceModel;
        }

        public static Issue ToIssueModel(this IssueEntity source, string issueStatus)
        {
            return new Issue
            {
                Id = source.Id,
                ProjectName = source.Project?.Name,
                ProjectVersion = source.ProjectVersion?.Name,
                Priority = source.Priority,
                Author = source.Author,
                AssignedTo = source.AssignedTo,
                StartDate = source.StartDate,
                Description = source.Description,
                Status = issueStatus
            };
        }

        public static Project ToProjectModel(this ProjectEntity source, decimal additionalTakenTime = decimal.Zero, DateTime? beginDate = null, DateTime? endDate = null)
        {
            var projectModel = new Project
            {
                Id = source.Id,
                Name = source.Name,
                BeginDate = source.BegintDate,
                HasProblems = source.HasProblems,
                Currency = source.Currency,
                PaidAmount = source.Payments.Sum(i => i.Amount)
            };

            var resourceModels = source.SoldResources.Select(i => i.ToResourceModel(beginDate, endDate)).ToArray();

            projectModel.Budget = resourceModels.Select(i => i.Rate * i.SoldHours).Sum();
            projectModel.SoldHours = resourceModels.Sum(i => i.SoldHours);
            projectModel.TakenMoney = resourceModels.Sum(i => i.TakenMoney);
            projectModel.TakenTime = resourceModels.Sum(i => i.TakenTime) + additionalTakenTime;

            return projectModel;
        }

        public static ProjectVerison ToProjectVerison(this ProjectVersionEntity source, IEnumerable<EmployeeTimeMoney> employeesWithoutResource, DateTime? beginDate = null, DateTime? endDate = null)
        {
            var projectVersionModel = new ProjectVerison
            {
                Name = source.Name,

                Status = source.Status,

                CreatedOn = source.CreatedOn.Date,

                Payments = source.Payments
                    .Select(payment => payment.ToPaymentRecord())
                    .ToArray(),

                Resources = source.SoldResources
                    .Where(i => i.ProjectVersion != null)
                    .Select(resource => resource.ToResourceModel(beginDate, endDate))
                    .ToArray(),

                EmployeesWithoutResource = employeesWithoutResource
                    .ToArray()
            };

            projectVersionModel.TakenTime = projectVersionModel.Resources.Sum(i => i.TakenTime) + projectVersionModel.EmployeesWithoutResource.Sum(i => i.TakenTime);
            projectVersionModel.TakenMoney = projectVersionModel.Resources.Sum(i => i.TakenMoney);

            return projectVersionModel;
        }

        public static Employee ToEmployeeModel(this EmployeeEntity source)
        {
            return new Employee
            {
                Id = source.Id,
                FullName = source.FullName
            };
        }
    }
}