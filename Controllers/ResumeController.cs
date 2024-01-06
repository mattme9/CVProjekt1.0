using CVProjekt1._0.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CVProjekt1._0.Controllers
{
    public class ResumeController : Controller
    {


        private readonly CVContext _context;
        private readonly UserManager<User> _userManager;

        public ResumeController(CVContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Create(Resume model)
        {


            var user = await _userManager.GetUserAsync(User);

             model.UserId = user.Id;
             var resume = new Resume
                {
                 Description = model.Description,
                 UserId = model.UserId

             };

                
                _context.Resumes.Add(resume);
                _context.SaveChanges();

                return RedirectToAction("Index");
         
        }


    }
}
