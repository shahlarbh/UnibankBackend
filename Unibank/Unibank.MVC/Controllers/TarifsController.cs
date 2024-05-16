using Microsoft.AspNetCore.Mvc;
using Unibank.DAL.DataContext;
using Unibank.MVC.Models;

namespace Unibank.MVC.Controllers
{
    public class TarifsController : Controller
    {
        public readonly AppDbContext _dbContext;

        public TarifsController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var tarifs = _dbContext.Tarifs.ToList();

            var model = new TarifsViewModel
            {
                Tarifs = tarifs,
            };

            return View(model);
        }
    }
}
