using Microsoft.AspNetCore.Mvc;

namespace Unibank.MVC.Areas.AdminPanel.Controllers
{
    public class DashboardController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
