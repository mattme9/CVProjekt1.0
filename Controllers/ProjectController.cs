using CVProjekt1._0.Models;
using CVProjekt1._0.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


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
            return View("_Create");
        }

        [HttpPost]
        public IActionResult CreateProject(CreateProjectViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Hämta inloggad användares ID
                var creatorId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Skapa nytt Project-objekt och fyll det med värden från vymodellen
                var newProject = new Project
                {
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    DesiredManpower = (int)viewModel.DesiredManpower,
                    CreatorId = creatorId // Användarens ID som skapar projektet
                };

                // Lägg till och spara det nya projektet i databasen
                _context.Projects.Add(newProject);
                _context.SaveChanges();

                return View("_Success"); // Eller den vy du vill visa efter att projektet skapats
            }

            return View(viewModel); // Om modellen inte är giltig, returnera vymodellen för att visa fel
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
            var thisProject = _context.Projects
                .OrderByDescending(p => p.ProjectId)
                .FirstOrDefault();

            if (thisProject == null)
            {
                return NotFound();
            }

            var viewModel = new ProjectDetailsViewModel
            {
                ProjectId = thisProject.ProjectId,
                Title = thisProject.Title,
                Description = thisProject.Description,
                DesiredManpower = thisProject.DesiredManpower,
                CreatorId = thisProject.CreatorId
            };

            return View("_Details", viewModel);
        }

        public IActionResult Edit(int projectId)
        {
            var thisProject = _context.Projects.FirstOrDefault(p => p.ProjectId == projectId);

            if (thisProject == null)
            {
                return NotFound();
            }

            var viewModel = new ProjectDetailsViewModel
            {
                ProjectId = thisProject.ProjectId,
                Title = thisProject.Title,
                Description = thisProject.Description,
                DesiredManpower = thisProject.DesiredManpower,
                CreatorId = thisProject.CreatorId
            };

            return View("_Edit", viewModel);
        }

		[HttpPost]
		public IActionResult EditProject(int projectId, ProjectDetailsViewModel viewModel)
		{
			
				// Hämta projektet från databasen
				var existingProject = _context.Projects.FirstOrDefault(p => p.ProjectId == projectId);

				if (existingProject != null)
				{
					// Uppdatera värden från vymodellen
					existingProject.Title = viewModel.Title;
					existingProject.Description = viewModel.Description;
					existingProject.DesiredManpower = viewModel.DesiredManpower;

					// Spara ändringarna i databasen
					_context.SaveChanges();

					return RedirectToAction("Details", new { projectId = existingProject.ProjectId });

				}
			

			// Om modellen inte är giltig eller projektet inte hittades, returnera till redigeringsvyn
			return View("_Edit", viewModel);
		}

		public IActionResult List()
        {
            var projects = _context.Projects.ToList();
            var viewModel = new ListProjectViewModel
            {
                Projects = projects,
            };

            return View("_List", viewModel);
        }
    }
}
