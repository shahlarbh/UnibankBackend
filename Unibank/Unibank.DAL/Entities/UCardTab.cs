namespace Unibank.DAL.Entities
{
    public class UCardTab : TimeStample
    {
        public string TabType { get; set; }
        public string TabLink { get; set; }
        public string? TabClass { get; set; }
        public int UCardIndexId { get; set; }
        public UCardIndex UCardIndex { get; set; }
    }
}
