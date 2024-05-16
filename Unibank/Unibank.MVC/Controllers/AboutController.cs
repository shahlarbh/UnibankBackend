using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unibank.DAL.DataContext;
using Unibank.MVC.Models;

namespace Unibank.MVC.Controllers
{
    public class AboutController : Controller
    {
        public readonly AppDbContext _dbContext;

        public AboutController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var topInfoBoxes = _dbContext.TopInfoBoxes.ToList();
            var bottomInfoBoxes = _dbContext.BottomInfoBoxes.ToList();
            var unibankMainValues = _dbContext.UnibankMainValues.ToList();
            var aboutBanners = _dbContext.AboutBanners.ToList();
            var aboutPageBoxes = _dbContext.AboutPageBoxes.ToList();
            var banks = _dbContext.Banks.Include(x => x.Awards).ToList();
            var awards = _dbContext.Awards.ToList();
            var licences = _dbContext.Licenses.ToList();
            var contactCordinates = _dbContext.ContactCordinates.ToList();
            var briefInfos = _dbContext.BriefInfos.ToList();

            var model = new AboutViewModel
            {
                TopInfoBoxes = topInfoBoxes,
                BottomInfoBoxes = bottomInfoBoxes,
                UnibankMainValues = unibankMainValues,
                AboutBanners = aboutBanners,
                AboutPageBoxes = aboutPageBoxes,
                Banks = banks,
                Awards = awards,
                Licenses = licences,
                ContactCordinates = contactCordinates,
                BriefInfos = briefInfos,
            };

            return View(model);
        }
    }
}