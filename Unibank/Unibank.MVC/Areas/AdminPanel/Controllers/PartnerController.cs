using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Unibank.DAL.DataContext;
using Unibank.DAL.Entities;
using Unibank.MVC.Areas.AdminPanel.Data;
using Unibank.MVC.Areas.AdminPanel.Models;
using Files = System.IO.File;

namespace Unibank.MVC.Areas.AdminPanel.Controllers
{
    public class PartnerController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public PartnerController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var partners = await _dbContext.Partners.Include(p => p.Category).ToListAsync();
            return View(partners);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var partner = await _dbContext.Partners.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);

            if (partner == null)
            {
                return NotFound();
            }
            return View(partner);
        }

        public IActionResult Create()
        {
            var categories = _dbContext.Categories.ToList();
            var viewModel = new PartnerCreateViewModel
            {
                Category = categories.Select(c => new SelectListItem
                { Text = c.Name, Value = c.Id.ToString() }).ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PartnerCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var existingPartner = await _dbContext.Partners.Include(p => p.Category)
                    .FirstOrDefaultAsync(p => p.Name == viewModel.Name);

                if (existingPartner != null)
                {
                    ModelState.AddModelError("Name", "This partner already exists");
                    viewModel.Category = _dbContext.Categories.Select(c => new SelectListItem
                    { Text = c.Name, Value = c.Id.ToString() }).ToList();
                    return View(viewModel);
                }

                var partner = new Partner
                {
                    Name = viewModel.Name,
                    Percentage = viewModel.Percentage,
                    NFC = viewModel.NFC,
                    CategoryId = viewModel.CategoryId
                };

                if (viewModel.PartnerImage != null && viewModel.PartnerImage.ContentType.Contains("image"))
                {
                    if (viewModel.PartnerImage.Length > 2 * 1024 * 1024)
                    {
                        ModelState.AddModelError("PartnerImage", "Max image size is 2mb");
                    }
                    else
                    {
                        var fileName = $"{Guid.NewGuid()}-{viewModel.PartnerImage.FileName}";
                        var path = Path.Combine(Constants.ImagePath, fileName);

                        using (var fileStream = new FileStream(path, FileMode.CreateNew))
                        {
                            await viewModel.PartnerImage.CopyToAsync(fileStream);
                        }

                        partner.Image = fileName;

                        _dbContext.Partners.Add(partner);
                        await _dbContext.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    ModelState.AddModelError("PartnerImage", "This file is not an image");
                }
            }

            viewModel.Category = _dbContext.Categories.Select(c => new SelectListItem
            { Text = c.Name, Value = c.Id.ToString() }).ToList();

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _dbContext.Partners.FirstOrDefaultAsync(p => p.Id == id);

            if (partner == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(partner.Image))
            {
                var imagePath = Path.Combine(Constants.ImagePath, partner.Image);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _dbContext.Partners.Remove(partner);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _dbContext.Partners.FindAsync(id);

            if (partner == null)
            {
                return NotFound();
            }

            var categories = await _dbContext.Categories.ToListAsync();
            var viewModel = new PartnerUpdateViewModel
            {
                Id = partner.Id,
                Name = partner.Name,
                Percentage = partner.Percentage,
                NFC = partner.NFC,
                CategoryId = partner.CategoryId,
                Categories = categories.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                    Selected = c.Id == partner.CategoryId
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, PartnerUpdateViewModel viewModel)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != viewModel.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                viewModel.Categories = await _dbContext.Categories
                    .Select(c => new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.Id.ToString(),
                        Selected = c.Id == viewModel.CategoryId
                    })
                    .ToListAsync();

                return View(viewModel);
            }

            var existingPartner = await _dbContext.Partners.FindAsync(id);

            if (existingPartner == null)
            {
                return NotFound();
            }

            var isDuplicateName = await _dbContext.Partners
                .AnyAsync(x => x.Name.ToLower() == viewModel.Name.ToLower() && x.Id != id);

            if (isDuplicateName)
            {
                ModelState.AddModelError("Name", "This partner already exists");

                viewModel.Categories = await _dbContext.Categories
                    .Select(c => new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.Id.ToString(),
                        Selected = c.Id == viewModel.CategoryId
                    })
                    .ToListAsync();

                return View(viewModel);
            }

            existingPartner.Name = viewModel.Name;
            existingPartner.Percentage = viewModel.Percentage;
            existingPartner.NFC = viewModel.NFC;
            existingPartner.CategoryId = viewModel.CategoryId;

            if (viewModel.PartnerImage != null)
            {
                if (!viewModel.PartnerImage.ContentType.Contains("image"))
                {
                    ModelState.AddModelError("PartnerImage", "This file is not an image");

                    viewModel.Categories = await _dbContext.Categories
                        .Select(c => new SelectListItem
                        {
                            Text = c.Name,
                            Value = c.Id.ToString(),
                            Selected = c.Id == viewModel.CategoryId
                        })
                        .ToListAsync();

                    return View(viewModel);
                }

                if (viewModel.PartnerImage.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("PartnerImage", "Max image size is 2mb");

                    viewModel.Categories = await _dbContext.Categories
                        .Select(c => new SelectListItem
                        {
                            Text = c.Name,
                            Value = c.Id.ToString(),
                            Selected = c.Id == viewModel.CategoryId
                        })
                        .ToListAsync();

                    return View(viewModel);
                }

                var oldImagePath = Path.Combine(Constants.ImagePath, existingPartner.Image);
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }

                var fileName = $"{Guid.NewGuid()}-{viewModel.PartnerImage.FileName}";
                var newPath = Path.Combine(Constants.ImagePath, fileName);

                using (var fileStream = new FileStream(newPath, FileMode.CreateNew))
                {
                    await viewModel.PartnerImage.CopyToAsync(fileStream);
                }

                existingPartner.Image = fileName;
            }

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}