namespace Unibank.DAL.Entities
{
    public class BriefInfo : TimeStample
    {
        public string Info { get; set; }
        public string Fullname { get; set; }
        public string ShortName { get; set; }
        public string LegalForm { get; set; }
        public string RegistrationDate { get; set; }
        public string Trademark { get; set; }
        public string Subsidiaries { get; set; }
    }
}
