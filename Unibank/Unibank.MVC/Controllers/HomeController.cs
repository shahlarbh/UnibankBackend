using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unibank.DAL.DataContext;
using Unibank.MVC.Models;

namespace Unibank.MVC.Controllers
{
    public class HomeController : Controller
    {
        public readonly AppDbContext _dbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var sliders = _dbContext.Sliders.OrderByDescending(s => s.Id).ToList();
            var crossBoxes = _dbContext.CrossBoxes.ToList();
            var uCardIndexs = _dbContext.UCardIndexs.Include(x => x.UCardTabs).ToList();
            var uCardTabs = _dbContext.UCardTabs.ToList();
            var uBanks = _dbContext.UBanks.Include(x => x.UBankImages).ToList();
            var uBankImages = _dbContext.UBankImages.ToList();
            var exchanges = _dbContext.Exchanges.Include(x => x.ExchangeCurrency)
                .ThenInclude(x => x.Currency).ToList();
            var firstCurrencyBoxes = _dbContext.FirstCurrencyBoxes.ToList();
            var secondCurrencyBoxes = _dbContext.SecondCurrencyBoxes.ToList();
            var connectionBanners = _dbContext.ConnectionBanners.ToList();
            var news = _dbContext.News.OrderByDescending(n => n.Id).Take(3).ToList();

            var model = new HomeViewModel
            {
                Sliders = sliders,
                CrossBoxes = crossBoxes,
                UCardIndexs = uCardIndexs,
                UCardTabs = uCardTabs,
                UBanks = uBanks,
                UBankImages = uBankImages,
                Exchanges = exchanges,
                FirstCurrencyBoxes = firstCurrencyBoxes,
                SecondCurrencyBoxes = secondCurrencyBoxes,
                ConnectionBanners = connectionBanners,
                NewsList = news,
            };

            return View(model);
        }

        public IActionResult Search(string searchedNavigation)
        {
            var navigations = _dbContext.HeaderNavigations.Where(x => x.Title.ToLower().Contains(searchedNavigation.ToLower())).ToList();

            return PartialView("_SearchedNavigationPartial", navigations);
        }
    }
}