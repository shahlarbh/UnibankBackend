namespace Unibank.DAL.Entities
{
    public class UTM : TimeStample
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Currency { get; set; }
    }
}
