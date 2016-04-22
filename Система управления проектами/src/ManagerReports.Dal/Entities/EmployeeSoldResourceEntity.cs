using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerReports.Dal.Entities
{
    [Table("EmployeeSoldResources")]
    public class EmployeeSoldResourceEntity : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public Guid SoldResourceId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public EmployeeEntity Employee { get; set; }

        [ForeignKey(nameof(SoldResourceId))]
        public SoldResourceEntity SoldResource { get; set; }
    }
}