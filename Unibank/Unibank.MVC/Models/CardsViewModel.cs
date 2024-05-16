using Unibank.DAL.Entities;

namespace Unibank.MVC.Models
{
    public class CardsViewModel
    {
        public List<Card> Cards = new List<Card>();
        public List<CardType> CardTypes = new List<CardType>();
        public List<UCardBanner> UCardBanners = new List<UCardBanner>();
        public List<UCardBannerOption> UCardBannerOptions = new List<UCardBannerOption>();
    }
}
