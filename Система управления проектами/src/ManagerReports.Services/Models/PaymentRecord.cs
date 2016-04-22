using System;

namespace ManagerReports.Services.Models
{
    public class PaymentRecord : BaseModel
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int? ProjectVersionId { get; set; }
    }
}