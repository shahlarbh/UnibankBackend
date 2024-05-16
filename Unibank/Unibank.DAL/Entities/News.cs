namespace Unibank.DAL.Entities
{
    public class News : TimeStample
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string BroadcastDate { get; set; }
    }
}
