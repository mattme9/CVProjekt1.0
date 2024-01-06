using CVProjekt1._0.Models;
using CVProjekt1._0.TestData;
using CVProjekt1._0.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Diagnostics;

namespace CVProjekt1._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CVContext _context;

        public HomeController(ILogger<HomeController> logger, CVContext context)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Index()
        {
            var selectedResumes = TestDataGenerator.GetResumes().ToList();
            var latestProject = TestDataGenerator.GetProjects()
                .OrderByDescending(p => p.ProjectId).FirstOrDefault();
            var users = TestDataGenerator.GetUsers();

            var viewModel = new HomePageViewModel
            {
                SelectedResumes = selectedResumes.Select(r => new ResumeViewModel
                {
                    ShortenedDescription = ShortenDescription(r.Description, 15),
                    Skills = r.Skills.ToList(),
                    User = r.User
                }).ToList(),
                LatestProject = latestProject,
                Users = users
            };
            return View(viewModel);
        }

        private string ShortenDescription(string description, int maxWords)
        {
            var words = description.Split(' ');
            if (words.Length > maxWords)
            {
                description = string.Join(' ', words.Take(maxWords)) + "...";
            }
            return description;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
