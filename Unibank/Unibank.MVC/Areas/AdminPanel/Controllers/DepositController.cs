using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unibank.DAL.DataContext;
using Unibank.DAL.Entities;

namespace Unibank.MVC.Areas.AdminPanel.Controllers
{
    public class DepositController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public DepositController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var deposits = await _dbContext.Deposits.ToListAsync();

            return View(deposits);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var deposit = await _dbContext.Deposits.FirstOrDefaultAsync(x => x.Id == id);

            if (deposit == null) return NotFound();

            return View(deposit);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Deposit deposit)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var isExist = await _dbContext.Deposits
                .AnyAsync(x => x.PageTitle.ToLower().Equals(deposit.PageTitle.ToLower()));

            if (isExist)
            {
                ModelState.AddModelError("PageTitle", "This deposit already exists");
                return View();
            }

            await _dbContext.Deposits.AddAsync(deposit);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var deposit = await _dbContext.Deposits.FindAsync(id);

            if (deposit == null) return NotFound();

            _dbContext.Deposits.Remove(deposit);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            var deposit = await _dbContext.Deposits.FindAsync(id);

            if (deposit == null) return NotFound();

            return View(deposit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Deposit deposit)
        {
            if (id == null) return NotFound();

            if (id != deposit.Id) return BadRequest();

            var existDeposit = await _dbContext.Deposits.FindAsync(id);

            var existName = await _dbContext.Deposits
                .AnyAsync(x => x.PageTitle.ToLower().Equals(deposit.PageTitle.ToLower()) && x.Id != id);

            if (existName)
            {
                ModelState.AddModelError("PageTitle", "This deposit already exists");
                return View();
            }

            existDeposit.PageTitle = deposit.PageTitle;
            existDeposit.Description = deposit.Description;
            existDeposit.Icon = deposit.Icon;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}