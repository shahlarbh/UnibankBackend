namespace Unibank.DAL.Entities
{
    public class Tarif : TimeStample
    {
        public string TarifTitle { get; set; }
        public string TarifPdf { get; set; }
        public string PdfSize { get; set; }
        public string BroadcastDate { get; set; }
    }
}
