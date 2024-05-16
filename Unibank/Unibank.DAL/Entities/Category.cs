namespace Unibank.DAL.Entities
{
    public class Category : TimeStample
    {
        public string Name { get; set; }
        public ICollection<Partner> Partners { get; set; }
    }
}
