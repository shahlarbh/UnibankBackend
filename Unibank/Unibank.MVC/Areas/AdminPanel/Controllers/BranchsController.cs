using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Unibank.DAL.DataContext;
using Unibank.DAL.Entities;
using Unibank.MVC.Areas.AdminPanel.Models;

namespace Unibank.MVC.Areas.AdminPanel.Controllers
{
    public class BranchsController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public BranchsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var branchs = await _dbContext.Branches.ToListAsync();

            return View(branchs);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null) return NotFound();

            var branch = await _dbContext.Branches
                .Include(x => x.SectionBranches)
                .ThenInclude(x => x.Section)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        public async Task<IActionResult> Create()
        {
            var sections = await _dbContext.Sections.ToListAsync();
            var sectionsForViewModel = new List<SelectListItem>();

            sections.ForEach(x => sectionsForViewModel.Add(new SelectListItem(x.Name, x.Id.ToString())));

            var model = new BranchCreateViewModel
            {
                Sections = sectionsForViewModel,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BranchCreateViewModel model)
        {
            var sections = await _dbContext.Sections.ToListAsync();
            var sectionsForViewModel = new List<SelectListItem>();

            sections.ForEach(x => sectionsForViewModel.Add(new SelectListItem(x.Name, x.Id.ToString())));

            var viewModel = new BranchCreateViewModel
            {
                Sections = sectionsForViewModel
            };

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var existingBranch = await _dbContext.Branches.FirstOrDefaultAsync(s => s.Name == model.Name);

            if (existingBranch != null)
            {
                ModelState.AddModelError(string.Empty, "This branch already exists");
                return View(viewModel);
            }

            var branch = new Branch
            {
                Name = model.Name,
                Address = model.Address,
                WorkTime = model.WorkTime,
                Description = model.Description,
            };

            var sectionBranches = new List<SectionBranch>();

            foreach (var sectionId in model.SectionIds)
            {
                sectionBranches.Add(new SectionBranch
                {
                    SectionId = sectionId,
                    BranchId = branch.Id
                });
            }

            branch.SectionBranches = sectionBranches;

            _dbContext.Branches.Add(branch);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var branch = await _dbContext.Branches
                .Include(x => x.SectionBranches)
                .ThenInclude(x => x.Section)
                .FirstOrDefaultAsync(x => x.Id == id);

            var sectionForViewModel = new List<SelectListItem>();
            var availableSections = await _dbContext.Sections.ToListAsync();

            branch.SectionBranches.ToList().ForEach(x =>
                sectionForViewModel.Add(new SelectListItem(x.Section.Name, x.Section.Id.ToString()))
            );

            var viewModel = new BranchUpdateViewModel
            {
                Name = branch.Name,
                Address = branch.Address,
                WorkTime = branch.WorkTime,
                Description = branch.Description,
                RemovedSections = sectionForViewModel,
                AvailableSections = availableSections
                .Select(b => new SelectListItem(b.Name, b.Id.ToString())).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, BranchUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var branch = await _dbContext.Branches
                    .Include(x => x.SectionBranches)
                    .FirstOrDefaultAsync(x => x.Id == id);

                branch.Name = model.Name;
                branch.Address = model.Address;
                branch.WorkTime = model.WorkTime;
                branch.Description = model.Description;

                if (model.RemovedSectionIds != null)
                {
                    var removedSectionIds = model.RemovedSectionIds.Distinct().ToList();

                    foreach (var sectionId in removedSectionIds)
                    {
                        var sectionBranchToRemove = branch.SectionBranches
                            .FirstOrDefault(x => x.SectionId == sectionId);

                        if (sectionBranchToRemove != null)
                        {
                            branch.SectionBranches.Remove(sectionBranchToRemove);
                        }
                    }
                }

                if (model.AddedSectionIds != null)
                {
                    var addedSectionIds = model.AddedSectionIds.Distinct().ToList();

                    foreach (var sectionId in addedSectionIds)
                    {
                        var section = await _dbContext.Sections.FindAsync(sectionId);

                        if (section != null)
                        {
                            branch.SectionBranches.Add(new SectionBranch
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

            model.AvailableSections = await _dbContext.Sections
                .Select(b => new SelectListItem(b.Name, b.Id.ToString()))
                .ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var branch = await _dbContext.Branches
                .FirstOrDefaultAsync(x => x.Id == id);

            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var branch = await _dbContext.Branches
                .FirstOrDefaultAsync(x => x.Id == id);

            if (branch == null)
            {
                return NotFound();
            }

            _dbContext.Branches.Remove(branch);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}