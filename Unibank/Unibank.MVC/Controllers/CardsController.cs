using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unibank.DAL.DataContext;
using Unibank.MVC.Models;

namespace Unibank.MVC.Controllers
{
    public class CardsController : Controller
    {
        public readonly AppDbContext _dbContext;

        public CardsController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var cards = _dbContext.Cards.ToList();
            var cardTypes = _dbContext.CardTypes.Include(x => x.Cards).ToList();
            var uCardBanners = _dbContext.UCardBanners.Include(x => x.UCardBannerOptions).ToList();
            var uCardBannerOptions = _dbContext.UCardBannerOptions.ToList();

            var model = new CardsViewModel
            {
                Cards = cards,
                CardTypes = cardTypes,
                UCardBanners = uCardBanners,
                UCardBannerOptions = uCardBannerOptions,
            };

            return View(model);
        }
    }
}