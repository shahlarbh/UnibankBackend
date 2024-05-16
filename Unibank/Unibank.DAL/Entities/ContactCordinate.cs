namespace Unibank.DAL.Entities
{
    public class ContactCordinate : TimeStample
    {
        public string Address { get; set; }
        public string PhoneNuber { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public string SWIFT { get; set; }
        public string VOEN { get; set; }
        public string Auditor { get; set; }
        public string AuditorAddress { get; set; }
        public string AuditorNumber { get; set; }
        public string SectionEmail { get; set; }
    }
}
