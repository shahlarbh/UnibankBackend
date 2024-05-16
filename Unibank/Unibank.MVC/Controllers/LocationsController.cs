using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unibank.DAL.DataContext;
using Unibank.MVC.Models;

namespace Unibank.MVC.Controllers
{
    public class LocationsController : Controller
    {
        public readonly AppDbContext _dbContext;

        public LocationsController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var sections = _dbContext.Sections.Include(x => x.SectionBranches)
                .ThenInclude(x => x.Branch).ToList();
            var terminals = _dbContext.Terminals.ToList();
            var utms = _dbContext.UTMs.ToList();
            var branchBanner = _dbContext.BranchBanners.ToList();

            var model = new LocationsViewModel
            {
                Sections = sections,
                Terminals = terminals,
                UTMs = utms,
                BranchBanners = branchBanner,
            };

            return View(model);
        }
    }
}
