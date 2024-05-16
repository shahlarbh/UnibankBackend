namespace Unibank.DAL.Entities
{
    public class Exchange : TimeStample
    {
        public string Type { get; set; }
        public ICollection<ExchangeCurrency> ExchangeCurrency { get; set; }
    }
}
