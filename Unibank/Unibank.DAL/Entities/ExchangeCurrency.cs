namespace Unibank.DAL.Entities
{
    public class ExchangeCurrency : Entity
    {
        public int ExchangeId { get; set; }
        public Exchange Exchange { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
    }
}
