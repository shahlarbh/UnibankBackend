namespace Unibank.DAL.Entities
{
    public class UCardBanner : TimeStample
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public ICollection<UCardBannerOption> UCardBannerOptions { get; set; }
    }
}
