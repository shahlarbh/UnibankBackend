using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unibank.DAL.DataContext;

namespace Unibank.MVC.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public readonly AppDbContext _dbContext;

        public HeaderViewComponent(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IViewComponentResult Invoke()
        {
            var header = _dbContext.Headers.Include(x => x.HeaderNavigations)
                .Include(x => x.Languages)
                .Include(x => x.Darkmodes)
                .Include(x => x.Menus).ToList();

            return View(header);
        }
    }
}
