using System.ComponentModel.DataAnnotations;

namespace ManagerReports.Web.ViewModels.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}