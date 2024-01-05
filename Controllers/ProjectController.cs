using CVProjekt1._0.Models;
using CVProjekt1._0.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CVProjekt1._0.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var viewModel = new CreateProjectViewModel();

            return View("_Create", viewModel);
        }

        public IActionResult Delete(int projectId)
        {
            return View("_Delete", projectId);
        }

        public IActionResult Details(int projectId)
        {
            var viewModel = new ProjectDetailsViewModel();

            return View("_Details", viewModel);
        }

        public IActionResult Edit(int projectId)
        {
            var viewModel = new ProjectDetailsViewModel();

            return View("_Edit", viewModel);
        }

        public IActionResult List()
        {
            var viewModel = new ListProjectViewModel();

            return View("_List", viewModel);
        }
    }
}
