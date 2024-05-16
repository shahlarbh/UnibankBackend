using Unibank.DAL.Entities;

namespace Unibank.MVC.Models
{
    public class LocationsViewModel
    {
        public List<Section> Sections = new List<Section>();
        public List<Branch> Branches = new List<Branch>();
        public List<Terminal> Terminals = new List<Terminal>();
        public List<UTM> UTMs = new List<UTM>();
        public List<BranchBanner> BranchBanners = new List<BranchBanner>();
    }
}
