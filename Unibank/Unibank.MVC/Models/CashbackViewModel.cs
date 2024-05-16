using Unibank.DAL.Entities;

namespace Unibank.MVC.Models
{
    public class CashbackViewModel
    {
        public List<CashbackPreview> CashbackPreviews = new List<CashbackPreview>();
        public List<Category> Categories = new List<Category>();
        public List<Partner> Partners { get; set; } = new List<Partner>();
        public string? PartnerCategoryName { get; set; }
        public List<CashbackInfoBox> CashbackInfoBoxes = new List<CashbackInfoBox>();
        public List<Filter> Filters = new List<Filter>();
    }
}
