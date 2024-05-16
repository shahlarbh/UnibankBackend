using Microsoft.AspNetCore.Mvc.Rendering;

namespace Unibank.MVC.Areas.AdminPanel.Models
{
    public class PartnerUpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Percentage { get; set; }
        public string NFC { get; set; }
        public int CategoryId { get; set; }
        public List<SelectListItem>? Categories { get; set; }
        public IFormFile? PartnerImage { get; set; }
    }
}
