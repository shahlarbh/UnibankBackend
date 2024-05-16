namespace Unibank.DAL.Entities
{
    public class CashbackInfoBox : TimeStample
    {
        public string TabTitle { get; set; }
        public string FirstTitle { get; set; }
        public string FirstContext { get; set; }
        public string LastTitle { get; set; }
        public string LastContext { get; set; }
    }
}
