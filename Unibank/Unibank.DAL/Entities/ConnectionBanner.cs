namespace Unibank.DAL.Entities
{
    public class ConnectionBanner : TimeStample
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Class { get; set; }
        public string Url { get; set; }
    }
}
