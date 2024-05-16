using Microsoft.AspNetCore.Mvc;
using Unibank.DAL.DataContext;
using Unibank.MVC.Models;

namespace Unibank.MVC.Controllers
{
    public class ContactsController : Controller
    {
        public readonly AppDbContext _dbContext;

        public ContactsController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var contacts = _dbContext.Contacts.ToList();

            var model = new ContactsViewModel
            {
                Contacts = contacts,
            };

            return View(model);
        }
    }
}
