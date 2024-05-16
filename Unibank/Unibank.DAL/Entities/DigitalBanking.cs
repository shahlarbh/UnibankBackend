namespace Unibank.DAL.Entities
{
    public class DigitalBanking : TimeStample
    {
        public string PageTitle { get; set; }
        public string Description { get; set; }
        public string PageUrl { get; set; }
        public string Icon { get; set; }
    }
}
