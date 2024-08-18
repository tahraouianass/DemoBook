using Microsoft.AspNetCore.Mvc;

namespace DemoBook.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
