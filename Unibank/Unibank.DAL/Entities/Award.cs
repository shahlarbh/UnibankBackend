namespace Unibank.DAL.Entities
{
    public class Award : TimeStample
    {
        public string Title { get; set; }
        public int BankId { get; set; }
        public Bank Bank { get; set; }
    }
}
