using Microsoft.AspNetCore.Mvc;
using Unibank.DAL.DataContext;
using Unibank.MVC.Models;

namespace Unibank.MVC.Controllers
{
    public class DigitalBankingController : Controller
    {
        public readonly AppDbContext _dbContext;

        public DigitalBankingController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var digitalBankings = _dbContext.DigitalBankings.ToList();

            var model = new DigitalBankingViewModel
            {
                DigitalBankings = digitalBankings,
            };

            return View(model);
        }
    }
}
