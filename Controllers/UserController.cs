using CVProjekt1._0.Models;
using Microsoft.AspNetCore.Mvc;

namespace CVProjekt1._0.Controllers
{
    public class UserController : Controller
    {
        private readonly CVContext _context;

        public UserController(CVContext context)
        {
            _context = context;
        }

        public IActionResult UserInfo()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = _context.Users.Find(User.Identity.Name);
                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public IActionResult Details
    }
}
