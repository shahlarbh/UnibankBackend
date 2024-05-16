namespace Unibank.DAL.Entities
{
    public class Menu : TimeStample
    {
        public string Title { get; set; }
        public string? Visibility { get; set; }
        public int HeaderId { get; set; }
        public Header Header { get; set; }
    }
}
