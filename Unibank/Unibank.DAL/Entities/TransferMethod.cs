namespace Unibank.DAL.Entities
{
    public class TransferMethod : Entity
    {
        public int TransferId { get; set; }
        public Transfer Transfer { get; set; }
        public int MethodId { get; set; }
        public Method Methods { get; set; }
    }
}
