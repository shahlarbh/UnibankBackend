using Microsoft.AspNetCore.Mvc.Rendering;

namespace Unibank.MVC.Areas.AdminPanel.Models
{
    public class BranchCreateViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string WorkTime { get; set; }
        public string Description { get; set; }
        public List<SelectListItem>? Sections { get; set; }
        public List<int> SectionIds { get; set; }
    }
}
