namespace Unibank.DAL.Entities
{
    public class FirstCurrencyBox : TimeStample
    {
        public string Currency { get; set; }
        public string CurrencyFlag { get; set; }
        public string CurrencyImage { get; set; }
        public string? Visibility { get; set; }
    }
}
