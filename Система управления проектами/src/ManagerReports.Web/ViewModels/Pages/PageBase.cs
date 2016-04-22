namespace ManagerReports.Web.ViewModels.Pages
{
    public class PageBase
    {
        public PageBase()
        {
        }

        public PageBase(string title)
        {
            PageTitle = title;
        }

        public string PageTitle { get; set; } = "Менеджерские отчёты";
    }
}