namespace Unibank.DAL.Entities
{
    public class UBankImage : TimeStample
    {
        public string Image { get; set; }
        public int UBankId { get; set; }
        public UBank UBank { get; set; }
    }
}
