using Unibank.DAL.Entities;

namespace Unibank.MVC.Models
{
    public class HRViewModel
    {
        public List<HRPageLink> PageLinks = new List<HRPageLink>();
        public List<BannerVideo> BannerVideos = new List<BannerVideo>();
        public List<HRPageBox> PageBoxes = new List<HRPageBox>();
        public List<Manager> Managers = new List<Manager>();
        public List<AboutUs> Abouts = new List<AboutUs>();
        public List<BankAdvantage> BankAdvantages = new List<BankAdvantage>();
        public List<MainValue> MainValues = new List<MainValue>();
    }
}
