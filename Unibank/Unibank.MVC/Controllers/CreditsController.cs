using Microsoft.AspNetCore.Mvc;
using Unibank.DAL.DataContext;
using Unibank.MVC.Models;

namespace Unibank.MVC.Controllers
{
    public class CreditsController : Controller
    {
        public readonly AppDbContext _dbContext;

        public CreditsController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var credits = _dbContext.Credits.ToList();

            var model = new CreditsViewModel
            {
                Credits = credits,
            };

            return View(model);
        }
    }
}
