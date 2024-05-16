using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Unibank.DAL.DataContext;
using Unibank.DAL.Entities;
using Unibank.MVC.Areas.AdminPanel.Models;

namespace Unibank.MVC.Areas.AdminPanel.Controllers
{
    public class SectionsController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public SectionsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var sections = await _dbContext.Sections.Include(x => x.SectionBranches)
                .ThenInclude(x => x.Branch).ToListAsync();

            return View(sections);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null) return NotFound();

            var section = await _dbContext.Sections
                .Include(x => x.SectionBranches)
                .ThenInclude(x => x.Branch)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (section == null)
            {
                return NotFound();
            }

            return View(section);
        }

        public IActionResult Create()
        {
            var branchs = _dbContext.Branches.ToList();
            var branchsForViewModel = new List<SelectListItem>();

            branchs.ForEach(x => branchsForViewModel.Add(new SelectListItem(x.Name, x.Id.ToString())));
            var model = new SectionCreateViewModel
            {
                Branchs = branchsForViewModel,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SectionCreateViewModel model)
        {
            var branchs = _dbContext.Branches.ToList();
            var branchsForViewModel = new List<SelectListItem>();

            branchs.ForEach(x => branchsForViewModel.Add(new SelectListItem(x.Name, x.Id.ToString())));

            var viewModel = new SectionCreateViewModel
            {
                Branchs = branchsForViewModel
            };

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var existingSection = await _dbContext.Sections.FirstOrDefaultAsync(s => s.Name == model.Name);

            if (existingSection != null)
            {
                ModelState.AddModelError(string.Empty, "This section already exists");
                return View(viewModel);
            }

            var section = new Section
            {
                Name = model.Name
            };

            var sectionBranchs = new List<SectionBranch>();

            foreach (var branchId in model.BranchIds)
            {
                if (!sectionBranchs.Any(sb => sb.BranchId == branchId))
                {
                    sectionBranchs.Add(new SectionBranch
                    {
                        SectionId = section.Id,
                        BranchId = branchId
                    });
                }
            }

            section.SectionBranches = sectionBranchs;

            _dbContext.Sections.Add(section);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            var section = _dbContext.Sections
                .Include(x => x.SectionBranches)
                .ThenInclude(x => x.Branch)
                .FirstOrDefault(x => x.Id == id);

            var branchForViewModel = new List<SelectListItem>();
            var availableBranches = _dbContext.Branches.ToList();

            section.SectionBranches.ToList().ForEach(x =>
                branchForViewModel.Add(new SelectListItem(x.Branch.Name, x.Branch.Id.ToString()))
            );

            var viewModel = new SectionUpdateViewModel
            {
                Name = section.Name,
                RemovedBranchs = branchForViewModel,
                AvailableBranchs = availableBranches
                .Select(b => new SelectListItem(b.Name, b.Id.ToString())).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, SectionUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var section = await _dbContext.Sections
                    .Include(x => x.SectionBranches)
                    .FirstOrDefaultAsync(x => x.Id == id);

                section.Name = model.Name;

                if (model.RemovedBranchIds != null)
                {
                    var removedBranchIds = model.RemovedBranchIds.Distinct().ToList();

                    foreach (var branchId in removedBranchIds)
                    {
                        var sectionBranchToRemove = section.SectionBranches
                            .FirstOrDefault(x => x.BranchId == branchId);

                        if (sectionBranchToRemove != null)
                        {
                            section.SectionBranches.Remove(sectionBranchToRemove);
                        }
                    }
                }

                if (model.AddedBranchIds != null)
                {
                    var addedBranchIds = model.AddedBranchIds.Distinct().ToList();

                    foreach (var branchId in addedBranchIds)
                    {
                        var branch = _dbContext.Branches.Find(branchId);

                        if (branch != null)
                        {
                            section.SectionBranches.Add(new SectionBranch
                            {
                                Section = section,
                                Branch = branch
                            });
                        }
                    }
                }

                await _dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            model.AvailableBranchs = _dbContext.Branches
                .Select(b => new SelectListItem(b.Name, b.Id.ToString()))
                .ToList();

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var section = _dbContext.Sections
                .FirstOrDefault(x => x.Id == id);

            if (section == null)
            {
                return NotFound();
            }

            return View(section);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var section = await _dbContext.Sections
                .FirstOrDefaultAsync(x => x.Id == id);

            if (section == null)
            {
                return NotFound();
            }

            _dbContext.Sections.Remove(section);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}