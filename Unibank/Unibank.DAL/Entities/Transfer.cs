namespace Unibank.DAL.Entities
{
    public class Transfer : TimeStample
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Commission { get; set; }
        public string Currency { get; set; }
        public string Location { get; set; }
        public string? Description { get; set; }
        public string Pdf { get; set; }
        public string? VariousBox { get; set; }
        public ICollection<TransferMethod> TransferMethods { get; set; }
    }
}
