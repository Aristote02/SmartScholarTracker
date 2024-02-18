using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentProgress.BusinessLogic.Requests;
using StudentProgress.BusinessLogic.Services.Interfaces;

namespace StudentProgress.Presentation.Controllers;

public class SubjectController : Controller
{
	private readonly ISubjectService _subjectService;
	public SubjectController(ISubjectService subjectService)
	{
		_subjectService = subjectService;
	}

    [Authorize(Roles = "admin, user")]
    public async Task<IActionResult> Index()
	{
		var subjects = await _subjectService.GetAllSubjectsAsync();

		return View(subjects);
	}

	[HttpGet]
    [Authorize(Roles = "admin")]
    public IActionResult Add()
	{
		return View();
	}

	[HttpPost]
    public async Task<IActionResult> Add(SubjectRequest subjectRequest)
	{
		if (ModelState.IsValid)
		{
			await _subjectService.AddSubjectAsync(subjectRequest);

			return RedirectToAction("Index");
		}

		return View();
	}

	[HttpGet]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Edit(int id)
	{
		var subject = await _subjectService.GetSubjectByIdAsync(id);

		return View(subject);
	}

	[HttpPost]
    public async Task<IActionResult> Edit(SubjectRequest subjectRequest)
	{
		if (ModelState.IsValid)
		{
			await _subjectService.UpdateSubjectAsync(subjectRequest);

			return RedirectToAction("Index");
		}
		return View();
	}

	[HttpGet]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Delete(int id)
	{
		await _subjectService.DeleteSubjectAsync(id);

		return RedirectToAction("Index");
	}
}
