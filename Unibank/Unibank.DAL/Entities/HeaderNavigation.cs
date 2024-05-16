namespace Unibank.DAL.Entities
{
    public class HeaderNavigation : TimeStample
    {
        public string Title { get; set; }
        public string TitleUrl { get; set; }
        public int HeaderId { get; set; }
        public Header Header { get; set; }
    }
}
