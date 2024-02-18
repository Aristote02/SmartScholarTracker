using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentProgress.BusinessLogic.Requests;
using StudentProgress.BusinessLogic.Services.Interfaces;

namespace StudentProgress.Presentation.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> Index()
        {
            var tests = await _testService.GetAllTestsAsync();

            return View(tests);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(TestRequest testRequest)
        {
            if (ModelState.IsValid)
            {
                await _testService.AddTestAsync(testRequest);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var test = await _testService.GetTestByIdAsync(id);

            return View(test);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm]TestRequest testRequest)
        {
            if (ModelState.IsValid)
            {
                await _testService.UpdateTestAsync(testRequest);

                return RedirectToAction("index");
            }

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _testService.DeleteTestAsync(id);

            return RedirectToAction("Index");
        }
    }
}
