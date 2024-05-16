using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unibank.DAL.DataContext;
using Unibank.DAL.Entities;

namespace Unibank.MVC.Areas.AdminPanel.Controllers
{
    public class UTMController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public UTMController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var utms = await _dbContext.UTMs.ToListAsync();

            return View(utms);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var utm = await _dbContext.UTMs.FirstOrDefaultAsync(x => x.Id == id);

            if (utm == null) return NotFound();

            return View(utm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UTM uTM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var isExist = await _dbContext.UTMs.AnyAsync(x => x.Name.ToLower().Equals(uTM.Name.ToLower()));

            if (isExist)
            {
                ModelState.AddModelError("Name", "This UTM is exist");

                return View();
            }

            await _dbContext.UTMs.AddAsync(uTM);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var utm = await _dbContext.UTMs.FindAsync(id);

            if (utm == null) return NotFound();

            _dbContext.UTMs.Remove(utm);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            var utm = await _dbContext.UTMs.FindAsync(id);

            if (utm == null) return NotFound();

            return View(utm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, UTM uTM)
        {
            if (id == null) return NotFound();

            if (id != uTM.Id) return BadRequest();

            var existUTM = await _dbContext.UTMs.FindAsync(id);

            var existName = await _dbContext.UTMs
                .AnyAsync(x => x.Name.ToLower().Equals(uTM.Name.ToLower()) && x.Id != id);

            if (existName)
            {
                ModelState.AddModelError("Name", "This UTM is exist");
                return View();
            }

            existUTM.Name = uTM.Name;
            existUTM.Address = uTM.Address;
            existUTM.Currency = uTM.Currency;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
