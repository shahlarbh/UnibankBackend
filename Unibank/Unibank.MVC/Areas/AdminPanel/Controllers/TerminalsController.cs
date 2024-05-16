using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unibank.DAL.DataContext;
using Unibank.DAL.Entities;

namespace Unibank.MVC.Areas.AdminPanel.Controllers
{
    public class TerminalsController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public TerminalsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var terminals = await _dbContext.Terminals.ToListAsync();

            return View(terminals);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var terminal = await _dbContext.Terminals.FirstOrDefaultAsync(x => x.Id == id);

            if (terminal == null) return NotFound();

            return View(terminal);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Terminal terminal)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var isExist = await _dbContext.Terminals
                .AnyAsync(x => x.Name.ToLower().Equals(terminal.Name.ToLower()));

            if (isExist)
            {
                ModelState.AddModelError("Name", "This terminal is exist");

                return View();
            }

            await _dbContext.Terminals.AddAsync(terminal);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var terminal = await _dbContext.Terminals.FindAsync(id);

            if (terminal == null) return NotFound();

            _dbContext.Terminals.Remove(terminal);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            var terminal = await _dbContext.Terminals.FindAsync(id);

            if (terminal == null) return NotFound();

            return View(terminal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Terminal terminal)
        {
            if (id == null) return NotFound();

            if (id != terminal.Id) return BadRequest();

            var existTerminal = await _dbContext.Terminals.FindAsync(id);

            var existName = await _dbContext.Terminals
                .AnyAsync(x => x.Name.ToLower().Equals(terminal.Name.ToLower()) && x.Id != id);

            if (existName)
            {
                ModelState.AddModelError("Name", "This terminal is exist");
                return View();
            }

            existTerminal.Name = terminal.Name;
            existTerminal.Address = terminal.Address;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
