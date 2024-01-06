using CVProjekt1._0.Models;
using CVProjekt1._0.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CVProjekt1._0.Controllers
{
    public class ProjectController : Controller
    {
        private readonly CVContext _context;
        
        public ProjectController(CVContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(CreateProjectViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var newProject = new Project
                {
                    // Här har vi metoder som skapar projektets fält genom viewModel-data.
                };

                _context.Projects.Add(newProject);
                _context.SaveChanges();

                return RedirectToAction("List");
            }

            return View("_Create", viewModel);
        }

        public IActionResult Delete(int projectId)
        {
            var project = _context.Projects.FirstOrDefault(p => p.ProjectId == projectId);
            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }

            return RedirectToAction("_Delete", projectId);
        }

        public IActionResult Details(int projectId)
        {
            var thisProject = _context.Projects.Include(p => p.User).FirstOrDefault(p => p.ProjectId == projectId);
            var viewModel = new ProjectDetailsViewModel
            {
                ProjectId = thisProject.ProjectId,
                User = thisProject.User
            };

            return View("_Details", viewModel);
        }

        public IActionResult Edit(int projectId)
        {
            var viewModel = new ProjectDetailsViewModel();

            return View("_Edit", viewModel);
        }

        public IActionResult List()
        {
            var projects = _context.Projects.ToList();

            return View("_List", projects);
        }
    }
}
