using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerReports.Dal.Entities
{
    [Table("ResourceTimeRecords")]
    public class ResourceTimeRecordEntity : BaseEntity
    {
        public Guid ResourceId { get; set; }
        public Guid TimeRecordId { get; set; }

        [ForeignKey(nameof(ResourceId))]
        public SoldResourceEntity Resource { get; set; }

        [ForeignKey(nameof(TimeRecordId))]
        public TimeRecordEntity TimeRecord { get; set; }
    }
}