using Microsoft.AspNetCore.Mvc.Rendering;

namespace Unibank.MVC.Areas.AdminPanel.Models
{
    public class PartnerCreateViewModel
    {
        public string Name { get; set; }
        public IFormFile? PartnerImage { get; set; }
        public double Percentage { get; set; }
        public string NFC { get; set; }
        public List<SelectListItem>? Category { get; set; }
        public int CategoryId { get; set; }
    }
}
