using Interfaces.DTO;

namespace Lab5WebApp.Models
{
    public class SPReportModel
    {
        public List<OrdersByMonth> ReportData { get; set; }
        public int SelectedMonth { get; set; }
        public int SelectedYear { get; set; }
    }
}
