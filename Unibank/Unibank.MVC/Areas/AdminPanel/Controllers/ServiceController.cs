using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unibank.DAL.DataContext;
using Unibank.DAL.Entities;

namespace Unibank.MVC.Areas.AdminPanel.Controllers
{
    public class ServicesController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public ServicesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _dbContext.Services.ToListAsync();

            return View(services);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var service = await _dbContext.Services.FirstOrDefaultAsync(x => x.Id == id);

            if (service == null) return NotFound();

            return View(service);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var isExist = await _dbContext.Services
                .AnyAsync(x => x.PageTitle.ToLower().Equals(service.PageTitle.ToLower()));

            if (isExist)
            {
                ModelState.AddModelError("PageTitle", "This service is exist");

                return View();
            }

            await _dbContext.Services.AddAsync(service);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var service = await _dbContext.Services.FindAsync(id);

            if (service == null) return NotFound();

            _dbContext.Services.Remove(service);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            var service = await _dbContext.Services.FindAsync(id);

            if (service == null) return NotFound();

            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Service service)
        {
            if (id == null) return NotFound();

            if (id != service.Id) return BadRequest();

            var existService = await _dbContext.Services.FindAsync(id);

            var existName = await _dbContext.Services
                .AnyAsync(x => x.PageTitle.ToLower().Equals(service.PageTitle.ToLower()) && x.Id != id);

            if (existName)
            {
                ModelState.AddModelError("PageTitle", "This title is exist");
                return View();
            }

            existService.PageTitle = service.PageTitle;
            existService.Description = service.Description;
            existService.Icon = service.Icon;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }

}
