using Microsoft.AspNetCore.Mvc;
using Unibank.DAL.DataContext;
using Unibank.MVC.Models;

namespace Unibank.MVC.Controllers
{
    public class DepositsController : Controller
    {
        public readonly AppDbContext _dbContext;

        public DepositsController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var deposits = _dbContext.Deposits.ToList();

            var model = new DepositsViewModel
            {
                Deposits = deposits,
            };

            return View(model);
        }
    }
}
