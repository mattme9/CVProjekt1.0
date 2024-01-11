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
                var creatorId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                
                var newProject = new Project
                {
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    DesiredManpower = (int)viewModel.DesiredManpower,
                    CreatorId = creatorId
                };

                _context.Projects.Add(newProject);
                _context.SaveChanges();

               
                var newParticipation = new ProjectUser
                {
                    ProjectId = newProject.ProjectId,
                    UserId = creatorId
                };

                _context.ProjectUsers.Add(newParticipation);
                _context.SaveChanges();

               
                TempData["ShowConfirmationModal"] = true;

                return View("_Success");
            }

            return View(viewModel);
        }


        public IActionResult Delete(int projectId)
        {
            var project = _context.Projects.FirstOrDefault(p => p.ProjectId == projectId);

            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();

                return RedirectToAction("List"); // Eller den vy du vill visa efter borttagning
            }

            return NotFound();
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

        [HttpPost]
        public IActionResult Participate(int projectId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Kolla om användaren redan deltar i projektet
                var existingParticipation = _context.ProjectUsers
                    .FirstOrDefault(pu => pu.ProjectId == projectId && pu.UserId == loggedInUserId);

                if (existingParticipation == null)
                {
                    // Lägg till deltagande i databasen
                    var newParticipation = new ProjectUser
                    {
                        ProjectId = projectId,
                        UserId = loggedInUserId
                    };

                    _context.ProjectUsers.Add(newParticipation);
                    _context.SaveChanges();

                    // Sätt TempData för bekräftelsemeddelande
                    TempData["ParticipationConfirmation"] = true;
                }

                // Lämplig omdirigering efter deltagande
                return RedirectToAction("List");
            }

            // Om användaren inte är inloggad, omdirigera till inloggningssidan
            return RedirectToAction("Login", "Account");
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
