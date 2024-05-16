using Microsoft.AspNetCore.Mvc;
using Unibank.DAL.DataContext;
using Unibank.MVC.Models;

namespace Unibank.MVC.Controllers
{
    public class HRController : Controller
    {
        public readonly AppDbContext _dbContext;

        public HRController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var pageLinks = _dbContext.HRPageLinks.ToList();
            var bannerVideos = _dbContext.BannerVideos.ToList();
            var pageBoxes = _dbContext.HRPageBoxes.ToList();
            var managers = _dbContext.Managers.ToList();
            var aboutUs = _dbContext.AboutUs.ToList();
            var bankAdvantages = _dbContext.BankAdvantages.ToList();
            var mainValues = _dbContext.MainValues.ToList();

            var model = new HRViewModel
            {
                PageLinks = pageLinks,
                BannerVideos = bannerVideos,
                PageBoxes = pageBoxes,
                Managers = managers,
                Abouts = aboutUs,
                BankAdvantages = bankAdvantages,
                MainValues = mainValues
            };

            return View(model);
        }

        public IActionResult Vacancies()
        {
            var pageLinks = _dbContext.HRPageLinks.ToList();
            var vacancies = _dbContext.Vacancies.ToList();

            var model = new VacancyViewModel
            { 
                PageLinks = pageLinks,
                Vacancies = vacancies 
            };

            return View(model);
        }
    }
}
