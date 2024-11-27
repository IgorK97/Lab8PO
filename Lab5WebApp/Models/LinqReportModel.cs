using DTO;
using Interfaces.DTO;

namespace Lab5WebApp.Models
{
    public class LinqReportModel
    {
        public List<ReportData>? ReportData { get; set; }
        public List<IngredientShortDto> IngredientList { get; set; }
        public int SelectedIngredientId { get; set; }
    }
}
