namespace Unibank.DAL.Entities
{
    public class CardType : TimeStample
    {
        public string Title { get; set; }
        public ICollection<Card> Cards { get; set; }
    }
}
