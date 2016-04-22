using System;
using System.Collections.Generic;
using ManagerReports.Services.Models;

namespace ManagerReports.Web.ViewModels.Models
{
    public class PaymentModel
    {
        public Guid ProjectId { get; set; }
        public string ProjectVersionName { get; set; }
        public IEnumerable<PaymentRecord> Payments { get; set; }
    }
}