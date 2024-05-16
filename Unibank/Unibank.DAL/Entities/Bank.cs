namespace Unibank.DAL.Entities
{
    public class Bank : TimeStample
    {
        public string Image { get; set; }
        public ICollection<Award> Awards { get; set; }
    }
}
