namespace Unibank.DAL.Entities
{
    public class UCardBannerOption : TimeStample
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public int UCardBannerId { get; set; }
        public UCardBanner UCardBanner { get; set; }
    }
}
