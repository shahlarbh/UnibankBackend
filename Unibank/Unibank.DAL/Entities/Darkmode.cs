namespace Unibank.DAL.Entities
{
    public class Darkmode : TimeStample
    {
        public string ModeIcon { get; set; }
        public string? Visibility { get; set; }
        public int HeaderId { get; set; }
        public Header Header { get; set; }
    }
}
