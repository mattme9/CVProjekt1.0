using CVProjekt1._0.Models;
using CVProjekt1._0.ViewModels;
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

        public IActionResult Details()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = _context.Users.SingleOrDefault(u => u.UserName == User.Identity.Name);

                UserInfoViewModel viewModel = new UserInfoViewModel
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Address = user.Address,
                    City = user.City,
                    Country = user.Country
                };
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}
