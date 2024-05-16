namespace Unibank.DAL.Entities
{
    public class Manager : TimeStample
    {
        public string Fullname { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
