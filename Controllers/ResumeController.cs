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
    public IActionResult Create(Resume model)
    {
        var user = _userManager.GetUserAsync(User).Result;

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
