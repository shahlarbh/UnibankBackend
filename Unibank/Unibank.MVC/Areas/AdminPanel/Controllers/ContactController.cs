using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unibank.DAL.DataContext;
using Unibank.DAL.Entities;

namespace Unibank.MVC.Areas.AdminPanel.Controllers
{
    public class ContactController : AdminController
    {
        private readonly AppDbContext _dbContext;

        public ContactController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var contacts = await _dbContext.Contacts.ToListAsync();

            return View(contacts);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var contact = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);

            if (contact == null) return NotFound();

            return View(contact);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var isExist = await _dbContext.Contacts
                .AnyAsync(x => x.PageTitle.ToLower().Equals(contact.PageTitle.ToLower()));

            if (isExist)
            {
                ModelState.AddModelError("PageTitle", "This contact already exists");
                return View();
            }

            await _dbContext.Contacts.AddAsync(contact);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var contact = await _dbContext.Contacts.FindAsync(id);

            if (contact == null) return NotFound();

            _dbContext.Contacts.Remove(contact);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            var contact = await _dbContext.Contacts.FindAsync(id);

            if (contact == null) return NotFound();

            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Contact contact)
        {
            if (id == null) return NotFound();

            if (id != contact.Id) return BadRequest();

            var existContact = await _dbContext.Contacts.FindAsync(id);

            var existName = await _dbContext.Contacts
                .AnyAsync(x => x.PageTitle.ToLower().Equals(contact.PageTitle.ToLower()) && x.Id != id);

            if (existName)
            {
                ModelState.AddModelError("PageTitle", "This contact already exists");
                return View();
            }

            existContact.PageTitle = contact.PageTitle;
            existContact.Description = contact.Description;
            existContact.Icon = contact.Icon;
            existContact.PageUrl = contact.PageUrl;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}