using System;
using System.Linq;
using ManagerReports.Dal;
using ManagerReports.Services.Interfaces;
using Microsoft.Data.Entity;

namespace ManagerReports.Services.Services
{
    public class TimeRecordService : ITimeRecordService
    {
        private readonly ManagerReportsContext _dbContext;

        public TimeRecordService(ManagerReportsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void UpdateTimeRecordResource(Guid timeRecordId, string resourceName)
        {
            var timeRecord = _dbContext.TimeRecords
                .Include(i => i.Resources)
                    .ThenInclude(i => i.Resource)
                .Single(i => i.Id == timeRecordId);

            var timeRecordResources = timeRecord.Resources.ToArray();

            foreach (var resource in timeRecordResources.Where(resource => resource.Resource.Name != resourceName))
            {
                timeRecord.Resources.Remove(resource);
            }

            _dbContext.TimeRecords.Update(timeRecord);
            _dbContext.SaveChanges();
        }
    }
}