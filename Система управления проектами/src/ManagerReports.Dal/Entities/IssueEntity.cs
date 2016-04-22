using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerReports.Dal.Entities
{
    [Table("Issues")]
    public class IssueEntity : RedmineEntity
    {
        public string Priority { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }

        /// <summary>
        ///     Автор задачи
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        ///     Кому задача назначена
        /// </summary>
        public string AssignedTo { get; set; }

        /// <summary>
        ///     Проект
        /// </summary>
        public Guid ProjectId { get; set; }
        [ForeignKey(nameof(ProjectId))]
        public ProjectEntity Project { get; set; }

        public int? ProjectVersionId { get; set; }
        [ForeignKey(nameof(ProjectVersionId))]
        public ProjectVersionEntity ProjectVersion { get; set; }

        public Guid IssueStatusId { get; set; }
        [ForeignKey(nameof(IssueStatusId))]
        public IssueStatusEntity IssueStatus { get; set; }

        public ICollection<TimeRecordEntity> TimeRecords { get; set; } 
    }
}