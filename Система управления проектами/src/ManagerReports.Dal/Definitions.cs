using System.ComponentModel.DataAnnotations;

namespace ManagerReports.Dal
{
    /// <summary>
    ///     Тип валют, в которых могут исчисляться рейты на проекте
    /// </summary>
    public enum CurrencyTypes
    {
        [Display(Name = "Не задана")]
        Undefined = 0,

        [Display(Name="Рубли")]
        Roubles = 1,

        [Display(Name = "Доллары")]
        Dollars = 2,

        [Display(Name = "Фунты")]
        Pounds = 3
    }
}