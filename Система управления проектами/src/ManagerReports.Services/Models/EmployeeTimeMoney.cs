namespace ManagerReports.Services.Models
{
    /// <summary>
    ///     Хранит информацию о потраченном сотрудником времени и деньгах на проект
    /// </summary>
    public class EmployeeTimeMoney
    {
        public string EmployeeFullName { get; set; }
        
        /// <summary>
        ///     Сумма потраченных денег
        /// </summary>
        public decimal TakenMoney { get; set; }

        /// <summary>
        ///     Сумма потраченного времени
        /// </summary>
        public decimal TakenTime { get; set; }
    }
}