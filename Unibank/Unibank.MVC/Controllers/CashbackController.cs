using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unibank.DAL.DataContext;
using Unibank.DAL.Entities;
using Unibank.MVC.Models;

namespace Unibank.MVC.Controllers
{
    public class CashbackController : Controller
    {
        public readonly AppDbContext _dbContext;

        public CashbackController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var cashbackPreviews = _dbContext.CashbackPreviews.ToList();
            var categories = _dbContext.Categories.Include(x => x.Partners).ToList();
            var partners = _dbContext.Partners.ToList();
            var cashbackInfoBoxes = _dbContext.CashbackInfoBoxes.ToList();
            var filters = _dbContext.Filters.ToList();

            var model = new CashbackViewModel
            {
                CashbackPreviews = cashbackPreviews,
                Categories = categories,
                Partners = partners,
                CashbackInfoBoxes = cashbackInfoBoxes,
                Filters = filters,
            };

            return View(model);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var partner = _dbContext.Partners.Include(p => p.Category).FirstOrDefault(p => p.Id == id);

            if (partner == null)
            {
                return NotFound();
            }

            var model = new CashbackViewModel
            {
                Partners = new List<Partner> { partner },
                PartnerCategoryName = partner.Category.Name
            };

            return View(model);
        }
    }
}