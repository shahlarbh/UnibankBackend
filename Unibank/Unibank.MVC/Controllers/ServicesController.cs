using Microsoft.AspNetCore.Mvc;
using Unibank.DAL.DataContext;
using Unibank.MVC.Models;

namespace Unibank.MVC.Controllers
{
    public class ServicesController : Controller
    {
        public readonly AppDbContext _dbContext;

        public ServicesController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var services = _dbContext.Services.ToList();

            var model = new ServicesViewModel
            {
                Services = services,
            };

            return View(model);
        }
    }
}
