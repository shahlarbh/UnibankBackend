namespace Unibank.DAL.Entities
{
    public class Currency : TimeStample
    {
        public string CurrencyName { get; set; }
        public string CurrencyValue { get; set; }
        public ICollection<ExchangeCurrency> ExchangeCurrency { get; set; }
    }
}
