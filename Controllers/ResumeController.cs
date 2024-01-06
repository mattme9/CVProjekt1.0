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

        switch (action)
        {
            case "AddEducation":
                // Lägg till logik för "AddEducation" knappen här
                break;
            case "AddSkill":
                // Lägg till logik för "AddSkill" knappen här
                break;
            case "AddExperience":
                // Lägg till logik för "AddExperience" knappen här
                break;
            case "SaveAboutMe":
                // Lägg till logik för "SaveAboutMe" knappen här

                // Här antar jag att du vill uppdatera beskrivningen för användaren
                var existingResume = _context.Resumes.FirstOrDefault(r => r.UserId == user.Id);

                if (existingResume != null)
                {
                    existingResume.Description = model.Description;
                }
                else
                {
                    // Skapa ett nytt Resume-objekt om det inte finns något befintligt
                    var newResume = new Resume
                    {
                        Description = model.Description,
                        UserId = model.UserId
                    };

                    _context.Resumes.Add(newResume);
                }

                break;
            default:
                // Lägg till en fallback om ingen matchning görs
                break;
        }

        // Gemensam logik som behöver köras oavsett knapptryckning
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

}
