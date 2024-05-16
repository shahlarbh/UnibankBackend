using Unibank.DAL.Entities;

namespace Unibank.MVC.Models
{
    public class AboutViewModel
    {
        public List<TopInfoBox> TopInfoBoxes = new List<TopInfoBox>();
        public List<BottomInfoBox> BottomInfoBoxes = new List<BottomInfoBox>();
        public List<UnibankMainValue> UnibankMainValues = new List<UnibankMainValue>();
        public List<AboutBanner> AboutBanners = new List<AboutBanner>();
        public List<AboutPageBox> AboutPageBoxes = new List<AboutPageBox>();
        public List<Bank> Banks = new List<Bank>();
        public List<Award> Awards = new List<Award>();
        public List<License> Licenses = new List<License>();
        public List<ContactCordinate> ContactCordinates = new List<ContactCordinate>();
        public List<BriefInfo> BriefInfos = new List<BriefInfo>();
    }
}
