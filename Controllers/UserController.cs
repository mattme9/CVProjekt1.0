using CVProjekt1._0.Models;
using CVProjekt1._0.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CVProjekt1._0.Controllers
{
    public class UserController : Controller
    {
        private readonly CVContext _context;
        private readonly UserManager<User> _userManager;

        public UserController(CVContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ShowSearchResult(string SearchString)
        {
            if (string.IsNullOrWhiteSpace(SearchString))
            {
                return View("ShowSearchForm");
            }

            var searchResults = await _context.Users
                .Where(u => u.UserName
                .Contains(SearchString) || u.Resume.Skills.Any(s => s.SkillName.Contains(SearchString)))
                .ToListAsync();

            if (searchResults == null)
            { 
                return View("ShowSearchForm");
            }

            return View("UserSearchResult", searchResults);
        }

        public IActionResult GoToUser(string id)
        {
            var user = _context.Users
                .Include(u => u.Resume)
                .Include(u => u.ProjectUsers)
                    .ThenInclude(pu => pu.Project)
                .FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            var projectViewModels = user.ProjectUsers.Select(pu => new ProjectDetailsViewModel
            {
                Description = pu.Project.Description,
                // Fyll på med andra projektrelaterade egenskaper här om det behövs
            }).ToList();

            VisitProfileViewModel viewModel = new VisitProfileViewModel
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ProfilePicture = user.ProfilePicturePath,
                Resume = user.Resume,
                Projects = projectViewModels,
                UserName = user.UserName,
            };

            return View("VisitProfile", viewModel);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserInfoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.SingleOrDefault(u => u.UserName == User.Identity.Name);
                user.Email = viewModel.Email;
                user.PhoneNumber = viewModel.PhoneNumber;
                user.FirstName = viewModel.FirstName;
                user.LastName = viewModel.LastName;
                user.Address = viewModel.Address;
                user.City = viewModel.City;
                user.Country = viewModel.Country;
                user.isPrivate = viewModel.isPrivate;

                _context.Update(user);
                _context.SaveChanges();
            }
                
            

            // If model state is not valid, redisplay the edit view with validation errors
            return View("Edit", viewModel);
        }
        public async Task<IActionResult> ChangePassword(UserChangePasswordViewModel userChangePasswordView)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                if (user == null)
                {
                    return NotFound();
                }

                var result = await _userManager.ChangePasswordAsync(user, userChangePasswordView.OldPassword, userChangePasswordView.NewPassword);

                if (result.Succeeded)
                {
                    return RedirectToAction("Details");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(userChangePasswordView);
        }

        public async Task<IActionResult> UploadProfilePicture(IFormFile profilePicture)
        {
            var imagePath = Path.Combine("wwwroot", "images", "profilePictures", profilePicture.FileName);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await profilePicture.CopyToAsync(stream);
            }
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.ProfilePicturePath = "/images/profilePictures/" + profilePicture.FileName;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Details");
        }
    }
}
