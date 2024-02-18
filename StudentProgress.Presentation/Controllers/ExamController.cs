using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentProgress.BusinessLogic.Requests;
using StudentProgress.BusinessLogic.Services.Interfaces;

namespace StudentProgress.Presentation.Controllers;

public class ExamController : Controller
{
    private readonly IExamService _examService;
    public ExamController(IExamService examService)
    {
        _examService = examService;
    }

    [Authorize(Roles = "admin,user")]
    public async Task<IActionResult> Index()
    {
        var exams = await _examService.GetAllExamAsync();

        return View(exams);
    }

    [HttpGet]
    [Authorize(Roles = "admin")]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(ExamRequest examRequest)
    {
        if (ModelState.IsValid)
        {
            await _examService.AddExamAsync(examRequest);

            return RedirectToAction("Index", "Exam");
        }

        return View();
    }

    [HttpGet]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Edit(int id)
    {
        var exam = await _examService.GetExamByIdAsync(id);

        return View(exam);
    
    }

    [HttpPost]
    public async Task<IActionResult> Edit([FromForm]ExamRequest examRequest)
    {
        if (ModelState.IsValid)
        {
            await _examService.UpdateExamAsync(examRequest);

            return RedirectToAction("Index", "Exam");
        }

        return View();
    }

    [HttpGet]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Delete(int id)
    {
        await _examService.DeleteExamAsync(id);

        return RedirectToAction("Index", "Exam");
    }

    [HttpGet]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> AveragePoint()
    {
        var exams = await _examService.GetAveragePointAsync();

        return View(exams);
    }

    [HttpGet]
    [Authorize(Roles = "admin,user")]
    public async Task<IActionResult> DifficultSubjects()
    {
        var exams = await _examService.DifficultSubjectPerSpecialtyAsync();

        return View(exams);
    }

    [HttpGet]
    [Authorize(Roles ="admin,user")]
    public async Task<IActionResult> SimplestSubject()
    {
        var exams = await _examService.SimplestSubjectPerSpecialtyAsync();

        return View(exams);
    }

    [HttpGet]
    public IActionResult MostSuccessfulStudent()
    {
        return View();
    }

	[HttpPost]
    [Authorize(Roles = "admin,user")]
    public async Task<IActionResult> MostSuccessfulStudent(DateTime startDate, DateTime endDate)
    {
        var successfulStudents = await _examService.MostSuccessfulStudentsAsync(startDate, endDate);
        
        return View(successfulStudents);
    }

    [HttpGet]
    [Authorize(Roles = "admin,user")]
    public IActionResult LaggingBehindStudent()
    {
        return View();
    }

    [HttpPost] 
    public async Task<IActionResult> LaggingBehindStudent(DateTime startDate, DateTime endDate)
    {
        var laggingBehindStudents = await _examService.LaggingBehindStudentAsync(startDate, endDate);

        return View(laggingBehindStudents);
    }
}
