using Microsoft.AspNetCore.Mvc.Rendering;

namespace Unibank.MVC.Areas.AdminPanel.Models
{
    public class SectionCreateViewModel
    {
        public string Name { get; set; }
        public List<SelectListItem>? Branchs { get; set; }
        public List<int> BranchIds { get; set; }
    }
}
