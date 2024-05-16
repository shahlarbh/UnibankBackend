using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unibank.DAL.DataContext;
using Unibank.DAL.Entities;

namespace Unibank.MVC.Areas.AdminPanel.Controllers
{
    public class DigitalBankingController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public DigitalBankingController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var digitalBankings = await _dbContext.DigitalBankings.ToListAsync();

            return View(digitalBankings);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var digitalBanking = await _dbContext.DigitalBankings.FirstOrDefaultAsync(x => x.Id == id);

            if (digitalBanking == null) return NotFound();

            return View(digitalBanking);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DigitalBanking digitalBanking)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var isExist = await _dbContext.DigitalBankings
                .AnyAsync(x => x.PageTitle.ToLower().Equals(digitalBanking.PageTitle.ToLower()));

            if (isExist)
            {
                ModelState.AddModelError("PageTitle", "This page already exists");
                return View();
            }

            await _dbContext.DigitalBankings.AddAsync(digitalBanking);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var digitalBanking = await _dbContext.DigitalBankings.FindAsync(id);

            if (digitalBanking == null) return NotFound();

            _dbContext.DigitalBankings.Remove(digitalBanking);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            var digitalBanking = await _dbContext.DigitalBankings.FindAsync(id);

            if (digitalBanking == null) return NotFound();

            return View(digitalBanking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, DigitalBanking digitalBanking)
        {
            if (id == null) return NotFound();

            if (id != digitalBanking.Id) return BadRequest();

            var existBanking = await _dbContext.DigitalBankings.FindAsync(id);

            var existName = await _dbContext.DigitalBankings
                .AnyAsync(x => x.PageTitle.ToLower().Equals(digitalBanking.PageTitle.ToLower()) && x.Id != id);

            if (existName)
            {
                ModelState.AddModelError("PageTitle", "This page already exists");
                return View();
            }

            existBanking.PageTitle = digitalBanking.PageTitle;
            existBanking.Description = digitalBanking.Description;
            existBanking.Icon = digitalBanking.Icon;
            existBanking.PageUrl = digitalBanking.PageUrl;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}