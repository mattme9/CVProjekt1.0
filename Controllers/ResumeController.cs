using CVProjekt1._0.Models;
using CVProjekt1._0.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class ResumeController : Controller
{
    private readonly CVContext _context;
    private readonly UserManager<User> _userManager;

    public ResumeController(CVContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        // Hämta aktuell användare
        var user = await _userManager.GetUserAsync(User);

        // Hämta beskrivningen från databasen baserat på användar-ID
        var description = _context.Resumes
            .Where(r => r.UserId == user.Id)
            .Select(r => r.Description)
            .FirstOrDefault();

        // Skapa ett ViewModel för att skicka data till vyn
        var viewModel = new ResumeViewModel
        {
            Description = description,
            // ... andra egenskaper du vill visa på sidan
        };

        return View(viewModel);
    }




    public IActionResult Create()
    {
        return View();
    }

	[HttpPost]
	public IActionResult Create(Resume model, string action)
	{
		var user = _userManager.GetUserAsync(User).Result;

		model.UserId = user.Id;

		
		var existingResume = _context.Resumes.FirstOrDefault(r => r.UserId == user.Id);

		if (existingResume == null)
		{
			existingResume = new Resume
			{
				UserId = user.Id
			};

			_context.Resumes.Add(existingResume);
		}

        switch (action)
        {
            case "AddEducation":
                Education newEducation = new Education
                {
                    ResumeId = existingResume.ResumeId,
                };
                _context.Educations.Add(newEducation);
                break;

            case "AddSkill":
                Skill newSkill = new Skill
                {
                    ResumeId = existingResume.ResumeId,
                };
                _context.Skills.Add(newSkill);
                break;

            case "AddExperience":
                var newExperience = new Experience
                {
                    ResumeId = existingResume.ResumeId,
                    ExperienceDescription = model.NewExperience
                };
                existingResume.Experiences.Add(newExperience);

                _context.Experiences.Add(newExperience);
                _context.SaveChanges();

                break;


            case "SaveAboutMe":
                existingResume.Description = model.Description;
                break;

            default:
                break;
        }

        _context.SaveChanges();

        return RedirectToAction("Index");
    }


}
