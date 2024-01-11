using CVProjekt1._0.Models;
using CVProjekt1._0.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
		try
		{
			var user = await _userManager.GetUserAsync(User);

			if (user == null)
			{
				TempData["ErrorMessage"] = "User not found.";
				return RedirectToAction("Index");
			}

			var description = _context.Resumes
				.Where(r => r.UserId == user.Id)
				.Select(r => r.Description)
				.FirstOrDefault();

			var education = _context.Resumes
				.Where(r => r.UserId == user.Id)
				.Select(r => r.Education)
				.FirstOrDefault();

			var skill = _context.Resumes
				.Where(r => r.UserId == user.Id)
				.Select(r => r.Skill)
				.FirstOrDefault();

			var experience = _context.Resumes
				.Where(r => r.UserId == user.Id)
				.Select(r => r.Experience)
				.FirstOrDefault();

			var viewModel = new ResumeViewModel
			{
				Description = description,
				Education = education,
				Skill = skill,
				Experience = experience
			};

			return View(viewModel);
		}
		catch (Exception ex)
		{
			TempData["ErrorMessage"] = "An error occurred while retrieving user information.";
			return RedirectToAction("Index");
		}
	}

	public IActionResult Create()
	{
		try
		{
			var user = _userManager.GetUserAsync(User).Result;

			if (user == null)
			{
				TempData["ErrorMessage"] = "User not found.";
				return RedirectToAction("Create");
			}

			var existingResume = _context.Resumes.FirstOrDefault(r => r.UserId == user.Id);

			if (existingResume == null)
			{
				existingResume = new Resume
				{
					UserId = user.Id
				};

				_context.Resumes.Add(existingResume);
			}

			return View(existingResume);
		}
		catch (Exception ex)
		{
			TempData["ErrorMessage"] = "An error occurred while processing the request.";
			return RedirectToAction("Create");
		}
	}

	[HttpPost]
	public IActionResult Create(Resume model, string action)
	{
		try
		{
			var user = _userManager.GetUserAsync(User).Result;

			if (user == null)
			{
				TempData["ErrorMessage"] = "User not found.";
				return RedirectToAction("Create");
			}

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

			string successMessage = "";

			switch (action)
			{
				case "AddEducation":
					if (!string.IsNullOrEmpty(model.Education))
					{
						existingResume.Education = model.Education;
						successMessage = "Education updated";
					}
					break;

				case "AddSkill":
					if (!string.IsNullOrEmpty(model.Skill))
					{
						existingResume.Skill = model.Skill;
						successMessage = "Skills updated";
					}
					break;

				case "AddExperience":
					if (!string.IsNullOrEmpty(model.Experience))
					{
						existingResume.Experience = model.Experience;
						successMessage = "Experience updated";
					}
					break;

				case "SaveAboutMe":
					existingResume.Description = model.Description;
					successMessage = "About me updated";
					break;

				default:
					break;
			}

			_context.SaveChanges();

			TempData["Message"] = successMessage + " successfully.";

			return RedirectToAction("Create");
		}
		catch (Exception ex)
		{
			TempData["ErrorMessage"] = "An error occurred while processing the request.";
			return RedirectToAction("Create");
		}
	}
}
