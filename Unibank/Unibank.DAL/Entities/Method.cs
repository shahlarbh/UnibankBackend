namespace Unibank.DAL.Entities
{
    public class Method : TimeStample
    {
        public string Name { get; set; }
        public string Action { get; set; }
        public ICollection<TransferMethod> TransferMethods { get; set; }
    }
}
