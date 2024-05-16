namespace Unibank.DAL.Entities
{
    public class FooterRightEnd : TimeStample
    {
       public string Logo { get; set; }
        public string LogoUrl { get; set; }
        public int FooterId { get; set; }
        public Footer Footer { get; set; }
    }
}
