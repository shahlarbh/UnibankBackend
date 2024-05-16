using Microsoft.AspNetCore.Mvc;
using Unibank.DAL.DataContext;
using Unibank.DAL.Entities;
using Unibank.MVC.Models;

namespace Unibank.MVC.Controllers
{
    public class NewsController : Controller
    {
        public readonly AppDbContext _dbContext;

        public NewsController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var news = _dbContext.News.OrderByDescending(n => n.Id).ToList();

            var model = new NewsViewModel
            {
                NewsList = news,
            };

            return View(model);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var newsEntity = _dbContext.News.Find(id);

            if (newsEntity == null)
            {
                return NotFound();
            }

            var model = new NewsViewModel
            {
                NewsList = new List<News> { newsEntity }
            };

            return View(model);
        }
    }
}
