namespace Unibank.DAL.Entities
{
    public class Card : TimeStample
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int CardTypeId { get; set; }
        public CardType CardType { get; set; }
    }
}
