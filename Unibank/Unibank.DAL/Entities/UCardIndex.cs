namespace Unibank.DAL.Entities
{
    public class UCardIndex : TimeStample
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string UCardImage { get; set; }
        public ICollection<UCardTab> UCardTabs { get; set; }
    }
}
