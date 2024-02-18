using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentProgress.BusinessLogic.Requests;
using StudentProgress.BusinessLogic.Services.Interfaces;

namespace StudentProgress.Presentation.Controllers
{
	public class SpecialtyController : Controller
	{
		private readonly ISpecialtyService _specialtyService;
		public SpecialtyController(ISpecialtyService specialtyService)
		{
			_specialtyService = specialtyService;
		}

        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> Index()
		{
			var specialties = await _specialtyService.GetAllSpecialtiesAsync();

			return View(specialties);
		}

		[HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
        public async Task<IActionResult> Add(SpecialtyRequest specialtyRequest)
		{
			if(ModelState.IsValid)
			{
				await _specialtyService.AddSpecialtyAsync(specialtyRequest);

				return RedirectToAction("Index");
			}

			return View();
		}

		[HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id)
		{
			var specialty = await _specialtyService.GetSpecialtyByIdAsync(id);

			return View(specialty);
		}

		[HttpPost]
        public async Task<IActionResult> Edit(SpecialtyRequest specialtyRequest)
		{
			if(ModelState.IsValid)
			{
				await _specialtyService.UpdateSpecialtyAsync(specialtyRequest);

				return RedirectToAction("Index");
			}

			return View();
		}

		[HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
		{
			await _specialtyService.DeleteSpecialty(id);

			return RedirectToAction("Index");
		}
	}
}
