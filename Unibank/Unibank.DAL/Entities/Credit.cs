namespace Unibank.DAL.Entities
{
    public class Credit : TimeStample
    {
        public string CreditType { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
