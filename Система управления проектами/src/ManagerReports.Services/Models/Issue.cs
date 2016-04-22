using System;

namespace ManagerReports.Services.Models
{
    public class Issue : BaseModel
    {
        public string ProjectName { get; set; }
        public string ProjectVersion { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string Author { get; set; }
        public string AssignedTo { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
    }
}