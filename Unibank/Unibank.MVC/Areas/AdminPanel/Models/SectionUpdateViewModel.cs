using Microsoft.AspNetCore.Mvc.Rendering;

namespace Unibank.MVC.Areas.AdminPanel.Models
{
    public class SectionUpdateViewModel
    {
        public string Name { get; set; }
        public List<SelectListItem>? RemovedBranchs { get; set; }
        public List<int>? RemovedBranchIds { get; set; }
        public List<SelectListItem>? AvailableBranchs { get; set; }
        public List<int>? AddedBranchIds { get; set; }
    }
}
