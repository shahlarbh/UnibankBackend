using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unibank.DAL.DataContext;

namespace Unibank.MVC.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public readonly AppDbContext _dbContext;

        public FooterViewComponent(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IViewComponentResult Invoke()
        {
            var footer = _dbContext.Footers.Include(x => x.FooterIcons)
                .Include(x => x.FooterLeftEnds)
                .Include(x => x.FooterRightEnds)
                .Include(x => x.FooterNavigations)
                .Include(x => x.FooterNavigationExtentions).ToList();

            return View(footer);
        }
    }
}
