using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unibank.DAL.DataContext;
using Unibank.DAL.Entities;

namespace Unibank.MVC.Areas.AdminPanel.Controllers
{
    public class NewsController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public NewsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var news = await _dbContext.News.ToListAsync();

            return View(news);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var news = await _dbContext.News.FirstOrDefaultAsync(x => x.Id == id);

            if (news == null) return NotFound();

            return View(news);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(News news)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var isExist = await _dbContext.News.AnyAsync(x => x.Title.ToLower().Equals(news.Title.ToLower()));

            if (isExist)
            {
                ModelState.AddModelError("Title", "This news is exist");

                return View();
            }

            await _dbContext.News.AddAsync(news);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var news = await _dbContext.News.FindAsync(id);

            if (news == null) return NotFound();

            _dbContext.News.Remove(news);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            var news = await _dbContext.News.FindAsync(id);

            if (news == null) return NotFound();

            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, News news)
        {
            if (id == null) return NotFound();

            if (id != news.Id) return BadRequest();

            var existNews = await _dbContext.News.FindAsync(id);

            var existName = await _dbContext.News
                .AnyAsync(x => x.Title.ToLower().Equals(news.Title.ToLower()) && x.Id != id);

            if (existName)
            {
                ModelState.AddModelError("Title", "This title is exist");
                return View();
            }

            existNews.Title = news.Title;
            existNews.Description = news.Description;
            existNews.BroadcastDate = news.BroadcastDate;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}