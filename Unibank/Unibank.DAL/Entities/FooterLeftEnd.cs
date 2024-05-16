namespace Unibank.DAL.Entities
{
    public class FooterLeftEnd : TimeStample
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int FooterId { get; set; }
        public Footer Footer { get; set; }
    }
}
