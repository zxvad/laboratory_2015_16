using System;

namespace ManagerReports.Services.Interfaces
{
    public interface ITimeRecordService
    {
        void UpdateTimeRecordResource(Guid timeRecordId, string resourceName);
    }
}