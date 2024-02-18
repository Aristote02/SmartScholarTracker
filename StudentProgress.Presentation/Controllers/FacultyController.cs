using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentProgress.BusinessLogic.Requests;
using StudentProgress.BusinessLogic.Services.Interfaces;

namespace StudentProgress.Presentation.Controllers
{
    public class FacultyController : Controller
    {
        private readonly IFacultyService _facultyService;
        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

		[Authorize(Roles = "admin, user")]
		public async Task<IActionResult> Index()
        {
            var faculties = await _facultyService.GetAllFacultiesAsync();

            return View(faculties);
        }

        [HttpGet]
		[Authorize(Roles = "admin")]
		public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> Add(FacultyRequest facultyRequest)
        {
            if(ModelState.IsValid)
            {
                await _facultyService.AddFacultyAsync(facultyRequest);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> Edit(int id)
        {
            var faculty = await _facultyService.GetFacultyByIdAsync(id);

            return View(faculty);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FacultyRequest facultyRequest)
        {
            if (ModelState.IsValid)
            {
                await _facultyService.UpdateFacultyAsync(facultyRequest);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> Delete(int id)
        {
            await _facultyService.DeleteFacultyAsync(id);

            return RedirectToAction("Index");
        }
    }
}
