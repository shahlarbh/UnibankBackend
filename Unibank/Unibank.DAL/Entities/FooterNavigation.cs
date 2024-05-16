namespace Unibank.DAL.Entities
{
    public class FooterNavigation : TimeStample
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public ICollection<FooterNavigationExtention> FooterNavigationExtentions { get; set; }
        public int FooterId { get; set; }
        public Footer Footer { get; set; }
    }
}
