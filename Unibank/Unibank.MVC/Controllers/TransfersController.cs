using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unibank.DAL.DataContext;
using Unibank.MVC.Models;

namespace Unibank.MVC.Controllers
{
    public class TransfersController : Controller
    {
        public readonly AppDbContext _dbContext;

        public TransfersController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IActionResult National()
        {
            var transferBanners = _dbContext.TransferBanners.ToList();
            var methods = _dbContext.Methods.Include(x => x.TransferMethods)
                .ThenInclude(x => x.Transfer).ToList();

            var model = new TransfersViewModel
            {
                TransferBanners = transferBanners,
                Methods = methods,
            };

            return View(model);
        }

        public IActionResult International()
        {
            var transferBanners = _dbContext.TransferBanners.ToList();
            var methods = _dbContext.Methods.Include(x => x.TransferMethods)
                .ThenInclude(x => x.Transfer).ToList();

            var model = new TransfersViewModel
            {
                TransferBanners = transferBanners,
                Methods = methods,
            };

            return View(model);
        }
    }
}
