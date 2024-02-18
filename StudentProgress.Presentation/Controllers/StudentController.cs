using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentProgress.BusinessLogic.Requests;
using StudentProgress.BusinessLogic.Services.Interfaces;

namespace StudentProgress.Presentation.Controllers;

public class StudentController : Controller
{
    private readonly IStudentService _studentService;
    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [Authorize(Roles = "admin, user")]
    public async Task<IActionResult> Index()
    {
        var students = await _studentService.GetAllStudentsAsync();

        return View(students);
    }

    [HttpGet]
    [Authorize(Roles = "admin")]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(StudentRequest studentRequest)
    {
        if(ModelState.IsValid)
        {
            await _studentService.AddStudentAsync(studentRequest);

            return RedirectToAction("Index", "Student");
        }

        return View();
    }

    [HttpGet]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Edit(int id) 
    {
        var student = await _studentService.GetStudentByIdAsync(id);

        return View(student);
    }

    [HttpPost]
    public async Task<IActionResult> Edit([FromForm] StudentRequest studentRequest)
    {
        if(ModelState.IsValid)
        {
            await _studentService.UpdateStudentAsync(studentRequest);

            return RedirectToAction("Index");
        }

        return View();
    }

    [HttpGet]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _studentService.DeleteStudentAsync(id);

        return RedirectToAction("Index");
    }
}
