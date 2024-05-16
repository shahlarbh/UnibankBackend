using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unibank.DAL.DataContext;
using Unibank.DAL.Entities;
using Unibank.MVC.Areas.AdminPanel.Models;

namespace Unibank.MVC.Areas.AdminPanel.Controllers
{
    public class CategoryController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public CategoryController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _dbContext.Categories.Include(x => x.Partners).ToListAsync();

            return View(categories);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var category = await _dbContext.Categories.Include(x => x.Partners).FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingCategory = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Name == model.Name);

                if (existingCategory != null)
                {
                    ModelState.AddModelError("Name", "This category already exists");
                    return View(model);
                }

                var newCategory = new Category
                {
                    Name = model.Name,
                };

                _dbContext.Categories.Add(newCategory);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var category = await _dbContext.Categories.FindAsync(id);

            if (category == null) return NotFound();

            _dbContext.Categories.Remove(category);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            var category = await _dbContext.Categories.FindAsync(id);

            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Category category)
        {
            if (id == null) return NotFound();

            if (id != category.Id) return BadRequest();

            var existCategory = await _dbContext.Categories.FindAsync(id);

            var existName = await _dbContext.Categories
                .AnyAsync(x => x.Name.ToLower().Equals(category.Name.ToLower()) && x.Id != id);

            if (existName)
            {
                ModelState.AddModelError("Name", "This category already exists");
                return View(category);
            }

            existCategory.Name = category.Name;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
