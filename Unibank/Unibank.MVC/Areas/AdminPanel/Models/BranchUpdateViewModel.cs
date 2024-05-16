using Microsoft.AspNetCore.Mvc.Rendering;

namespace Unibank.MVC.Areas.AdminPanel.Models
{
    public class BranchUpdateViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string WorkTime { get; set; }
        public string Description { get; set; }
        public List<SelectListItem>? RemovedSections { get; set; }
        public List<int>? RemovedSectionIds { get; set; }
        public List<SelectListItem>? AvailableSections { get; set; }
        public List<int>? AddedSectionIds { get; set; }
    }
}
