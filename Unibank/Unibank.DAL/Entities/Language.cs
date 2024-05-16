namespace Unibank.DAL.Entities
{
    public class Language : TimeStample
    {
        public string Name { get; set; }
        public string? Visibility { get; set; }
        public int HeaderId { get; set; }
        public Header Header { get; set; }
    }
}
