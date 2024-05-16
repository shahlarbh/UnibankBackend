namespace Unibank.DAL.Entities
{
    public class FooterIcon : TimeStample
    {
        public string Icon { get; set; }
        public string IconUrl { get; set; }
        public int FooterId { get; set; }
        public Footer Footer { get; set; }
    }
}
