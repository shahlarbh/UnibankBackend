namespace Unibank.DAL.Entities
{
    public class UBank : TimeStample
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public ICollection<UBankImage> UBankImages { get; set; }
    }
}
