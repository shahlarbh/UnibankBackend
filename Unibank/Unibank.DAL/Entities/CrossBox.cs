namespace Unibank.DAL.Entities
{
    public class CrossBox : TimeStample
    {
        public string Title { get; set; }
        public string MainDigit { get; set; }
        public string Suffix { get; set; }
        public string LinkType { get; set; }
        public string Url { get; set; }
    }
}
