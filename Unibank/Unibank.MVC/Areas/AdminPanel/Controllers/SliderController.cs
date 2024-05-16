using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unibank.DAL.DataContext;
using Unibank.DAL.Entities;
using Unibank.MVC.Areas.AdminPanel.Data;
using Files = System.IO.File;

namespace Unibank.MVC.Areas.AdminPanel.Controllers
{
    public class SliderController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public SliderController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var sliders = await _dbContext.Sliders.ToListAsync();

            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid)
                return View();

            var isExist = await _dbContext.Sliders
                .AnyAsync(x => x.Title.ToLower().Equals(slider.Title.ToLower()));

            if (isExist)
            {
                ModelState.AddModelError("Title", "This slider is exist");

                return View();
            }

            if (!slider.Image.ContentType.Contains("image"))
            {
                ModelState.AddModelError("Image", "This file is not an image");

                return View();
            }

            if (slider.Image.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError("Image", "Max image size is 2mb");

                return View();
            }

            var fileName = $"{Guid.NewGuid()}-{slider.Image.FileName}";

            var path = Path.Combine(Constants.ImagePath, fileName);

            using (var fileStream = new FileStream(path, FileMode.CreateNew))
            {
                await slider.Image.CopyToAsync(fileStream);

                fileStream.Close();
            }

            slider.SliderImage = fileName;

            await _dbContext.Sliders.AddAsync(slider);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var slider = await _dbContext.Sliders.FirstOrDefaultAsync(x => x.Id == id);

            if (slider == null) return NotFound();

            return View(slider);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            var slider = await _dbContext.Sliders.FindAsync(id);

            if (slider == null) return NotFound();

            return View(slider);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int? id, Slider slider)
        {
            if (id == null)
                return NotFound();

            if (id != slider.Id)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return View(slider);
            }

            var existSlider = await _dbContext.Sliders.FindAsync(id);

            if (existSlider == null)
                return NotFound();

            var existName = await _dbContext.Sliders
                .AnyAsync(x => x.Title.ToLower().Equals(slider.Title.ToLower()) && x.Id != id);

            if (existName)
            {
                ModelState.AddModelError("Title", "This slider is exist");
                return View(slider);
            }

            existSlider.Title = slider.Title;
            existSlider.Description = slider.Description;
            existSlider.Url = slider.Url;

            if (slider.Image != null)
            {
                if (!slider.Image.ContentType.Contains("image"))
                {
                    ModelState.AddModelError("Image", "This file is not an image");
                    return View(slider);
                }

                if (slider.Image.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError("Image", "Max image size is 2mb");
                    return View(slider);
                }

                var oldImagePath = Path.Combine(Constants.ImagePath, existSlider.SliderImage);
                if (Files.Exists(oldImagePath))
                {
                    Files.Delete(oldImagePath);
                }

                var fileName = $"{Guid.NewGuid()}-{slider.Image.FileName}";
                var newPath = Path.Combine(Constants.ImagePath, fileName);

                using (var fileStream = new FileStream(newPath, FileMode.CreateNew))
                {
                    await slider.Image.CopyToAsync(fileStream);
                }

                existSlider.SliderImage = fileName;
            }

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = await _dbContext.Sliders.FindAsync(id);

            if (slider == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(slider.SliderImage))
            {
                var imagePath = Path.Combine(Constants.ImagePath, slider.SliderImage);
                if (Files.Exists(imagePath))
                {
                    Files.Delete(imagePath);
                }
            }

            _dbContext.Sliders.Remove(slider);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}