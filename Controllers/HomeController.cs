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
        private readonly CVContext _cvContext;

        public HomeController(ILogger<HomeController> logger, CVContext cvContext)
        {
            _logger = logger;            
            _cvContext = cvContext;

        }

        public IActionResult Index()
        {
            var selectedResumes = TestDataGenerator.GetResumes().ToList();
            var latestProject = TestDataGenerator.GetProjects()
                .OrderByDescending(p => p.ProjectId).FirstOrDefault();
            var users = TestDataGenerator.GetUsers();

            var viewModel = new HomePageViewModel
            {
                SelectedResumes = selectedResumes,
                LatestProject = latestProject,
                Users = users
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
