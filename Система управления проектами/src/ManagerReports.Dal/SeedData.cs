using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using ManagerReports.Dal.Entities;

namespace ManagerReports.Dal
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetService<ManagerReportsContext>();

            if (dbContext.Database == null)
            {
                throw new Exception("Database is null");
            }

            AddPayments(dbContext);
            dbContext.SaveChanges();

            AddSoldResources(dbContext);
            dbContext.SaveChanges();
        }

        private static void AddPayments(ManagerReportsContext dbContext)
        {
            if (dbContext.Payments.Any())
            {
                return;
            }

            dbContext.Payments.AddRange(
                new PaymentRecordEntity
                {
                    Date = new DateTime(2015, 12, 29).Date,
                    Amount = 338000.0m,
                    Project = dbContext.Projects.FirstOrDefault(i => i.ExternalId == 352),
                    ProjectVersion = dbContext.ProjectVersions.FirstOrDefault(i => i.ExternalId == 243)
                });
        }

        private static void AddSoldResources(ManagerReportsContext dbContext)
        {
            if (dbContext.SoldResources.Any())
            {
                return;
            }

            dbContext.SoldResources.AddRange(
                new SoldResourceEntity
                {
                    Name = "Дизайн",
                    Rate = 1400.0m,
                    Hours = 120.0m,
                    Employees = new[]
                    {
                        new EmployeeSoldResourceEntity
                        {
                            Employee = dbContext.Employees.FirstOrDefault(i => i.LastName == "Анкудинов")
                        }
                    },
                    Project = dbContext.Projects.FirstOrDefault(i => i.ExternalId == 352),
                    ProjectVersion = dbContext.ProjectVersions.FirstOrDefault(i => i.ExternalId == 243)
                },

                new SoldResourceEntity
                {
                    Name = "Управление проектом",
                    Rate = 1300.0m,
                    Hours = 60.0m,
                    Employees = new[]
                    {
                        new EmployeeSoldResourceEntity
                        {
                            Employee = dbContext.Employees.FirstOrDefault(i => i.LastName == "Шемякин")
                        }
                    },
                    Project = dbContext.Projects.FirstOrDefault(i => i.ExternalId == 352),
                    ProjectVersion = dbContext.ProjectVersions.FirstOrDefault(i => i.ExternalId == 243)
                },

                new SoldResourceEntity
                {
                    Name = "Разработка",
                    Rate = 1500.0m,
                    Hours = 240.0m,
                    Employees = new[]
                    {
                        new EmployeeSoldResourceEntity
                        {
                            Employee = dbContext.Employees.FirstOrDefault(i => i.LastName == "Макшаков")
                        },

                        new EmployeeSoldResourceEntity
                        {
                            Employee = dbContext.Employees.FirstOrDefault(i => i.LastName == "Красноперов")
                        }
                    },
                    Project = dbContext.Projects.FirstOrDefault(i => i.ExternalId == 352),
                    ProjectVersion = dbContext.ProjectVersions.FirstOrDefault(i => i.ExternalId == 243)
                },

                new SoldResourceEntity
                {
                    Name = "Тестирование",
                    Rate = 1000.0m,
                    Hours = 70.0m,
                    Employees = new[]
                    {
                        new EmployeeSoldResourceEntity
                        {
                            Employee = dbContext.Employees.FirstOrDefault(i => i.LastName == "Калинин")
                        }
                    },
                    Project = dbContext.Projects.FirstOrDefault(i => i.ExternalId == 352),
                    ProjectVersion = dbContext.ProjectVersions.FirstOrDefault(i => i.ExternalId == 243)
                },

                new SoldResourceEntity
                {
                    Name = "Дизайн",
                    Rate = 1200.0m,
                    Hours = 256.0m,
                    Employees = new[]
                    {
                        new EmployeeSoldResourceEntity
                        {
                            Employee = dbContext.Employees.FirstOrDefault(i => i.LastName == "Анкудинов")
                        },

                        new EmployeeSoldResourceEntity
                        {
                            Employee = dbContext.Employees.FirstOrDefault(i => i.LastName == "Учанов")
                        }
                    },
                    Project = dbContext.Projects.FirstOrDefault(i => i.ExternalId == 331),
                    ProjectVersion = dbContext.ProjectVersions.FirstOrDefault(i => i.ExternalId == 226)
                },

                new SoldResourceEntity
                {
                    Name = "Аналитика",
                    Rate = 1200.0m,
                    Hours = 172.0m,
                    Employees = new[]
                    {
                        new EmployeeSoldResourceEntity
                        {
                            Employee = dbContext.Employees.FirstOrDefault(i => i.LastName == "Рахимова")
                        }
                    },
                    Project = dbContext.Projects.FirstOrDefault(i => i.ExternalId == 331),
                    ProjectVersion = dbContext.ProjectVersions.FirstOrDefault(i => i.ExternalId == 225)
                },

                new SoldResourceEntity
                {
                    Name = "Прототипирование",
                    Rate = 1200.0m,
                    Hours = 80.0m,
                    Project = dbContext.Projects.FirstOrDefault(i => i.ExternalId == 331),
                    ProjectVersion = dbContext.ProjectVersions.FirstOrDefault(i => i.ExternalId == 225),
                    Employees = new[]
                    {
                        new EmployeeSoldResourceEntity
                        {
                            Employee = dbContext.Employees.FirstOrDefault(i => i.LastName == "Учанов")
                        },

                        new EmployeeSoldResourceEntity
                        {
                            Employee = dbContext.Employees.FirstOrDefault(i => i.LastName == "Анкудинов")
                        }
                    }
                },

                new SoldResourceEntity
                {
                    Name = "Создание контента",
                    Rate = 800.0m,
                    Hours = 120.0m,
                    Project = dbContext.Projects.FirstOrDefault(i => i.ExternalId == 331)
                },

                new SoldResourceEntity
                {
                    Name = "Разработка",
                    Rate = 800.0m,
                    Hours = 120.0m,
                    Project = dbContext.Projects.FirstOrDefault(i => i.ExternalId == 331),
                    ProjectVersion = dbContext.ProjectVersions.FirstOrDefault(i => i.ExternalId == 225),
                    Employees = new[]
                    {
                        new EmployeeSoldResourceEntity
                        {
                            Employee = dbContext.Employees.FirstOrDefault(i => i.LastName == "Моглиев")
                        },

                        new EmployeeSoldResourceEntity
                        {
                            Employee = dbContext.Employees.FirstOrDefault(i => i.LastName == "Богатырев")
                        }
                    }
                },

                new SoldResourceEntity
                {
                    Name = "Управление проектом",
                    Rate = 1200.0m,
                    Hours = 130.0m,
                    Project = dbContext.Projects.FirstOrDefault(i => i.ExternalId == 331),
                    ProjectVersion = dbContext.ProjectVersions.FirstOrDefault(i => i.ExternalId == 225),
                    Employees = new[]
                    {
                        new EmployeeSoldResourceEntity
                        {
                            Employee = dbContext.Employees.FirstOrDefault(i => i.LastName == "Рахимова")
                        },

                        new EmployeeSoldResourceEntity
                        {
                            Employee = dbContext.Employees.FirstOrDefault(i => i.LastName == "Шемякин")
                        }
                    }
                });
        }
    }
}