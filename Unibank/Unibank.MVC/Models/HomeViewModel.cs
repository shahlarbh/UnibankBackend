using Unibank.DAL.Entities;

namespace Unibank.MVC.Models
{
    public class HomeViewModel
    {
        public List<Slider> Sliders = new List<Slider>();
        public List<CrossBox> CrossBoxes = new List<CrossBox>();
        public List<UCardIndex> UCardIndexs = new List<UCardIndex>();
        public List<UCardTab> UCardTabs = new List<UCardTab>();
        public List<UBank> UBanks = new List<UBank>();
        public List<UBankImage> UBankImages = new List<UBankImage>();
        public List<Exchange> Exchanges = new List<Exchange>();
        public List<Currency> Currencies = new List<Currency>();
        public List<FirstCurrencyBox> FirstCurrencyBoxes = new List<FirstCurrencyBox>();
        public List<SecondCurrencyBox> SecondCurrencyBoxes = new List<SecondCurrencyBox>();
        public List<ConnectionBanner> ConnectionBanners = new List<ConnectionBanner>();
        public List<News> NewsList = new List<News>();
    }
}
