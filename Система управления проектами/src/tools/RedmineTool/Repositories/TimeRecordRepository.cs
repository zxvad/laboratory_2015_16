using System.Collections.Generic;
using ManagerReports.Dal;
using ManagerReports.Dal.Entities;
using RedmineTool.Interfaces.Repositories;
using RedmineTool.Models;
using System.Linq;

namespace RedmineTool.Repositories
{
    public class TimeRecordRepository : ITimeRecordRepository
    {
        private readonly ManagerReportsContext _dbContext;

        public TimeRecordRepository()
        {
            _dbContext = new ManagerReportsContext(new Startup().Configuration);
        }

        public void Save(IEnumerable<RedmineTimeRecord> entities)
        {
            var timeRecords = entities.Where(entity => entity.Issue != null).Select(timeRecord => new TimeRecordEntity
            {
                ExternalId = timeRecord.Id,
                Hours = timeRecord.Hours,
                Comments = timeRecord.Comments,
                Activity = timeRecord.Activity?.Name,
                Date = timeRecord.SpentOn,
                Employee = _dbContext.Employees.FirstOrDefault(employee => employee.ExternalId == timeRecord.User.Id),
                Issue = _dbContext.Issues.FirstOrDefault(issue => issue.ExternalId == timeRecord.Issue.Id)
            })
                .Where(timeRecord => timeRecord.Issue != null && timeRecord.Employee != null);

            foreach (var timeRecordEntity in timeRecords)
            {
                var sourceTimeRecord = _dbContext.TimeRecords.FirstOrDefault(timeRecord => timeRecord.ExternalId == timeRecordEntity.ExternalId);

                if (sourceTimeRecord == null)
                {
                    _dbContext.TimeRecords.Add(timeRecordEntity);
                }
                else
                {
                    sourceTimeRecord.Activity = timeRecordEntity.Activity;
                    sourceTimeRecord.Comments = timeRecordEntity.Comments;
                    sourceTimeRecord.Date = timeRecordEntity.Date;
                    sourceTimeRecord.Hours = timeRecordEntity.Hours;

                    _dbContext.TimeRecords.Update(sourceTimeRecord);
                }
            }

            _dbContext.SaveChanges();
        }
    }
}