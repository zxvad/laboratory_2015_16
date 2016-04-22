using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerReports.Dal.Entities
{
    [Table("IssueStatuses")]
    public class IssueStatusEntity : RedmineEntity
    {
        public string Name { get; set; }

        public ICollection<IssueEntity> Issues { get; set; } 
    }
}