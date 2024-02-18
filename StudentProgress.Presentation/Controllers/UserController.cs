using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentProgress.BusinessLogic.Exceptions;
using StudentProgress.BusinessLogic.Requests;
using StudentProgress.BusinessLogic.Services.Interfaces;

namespace StudentProgress.Presentation.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;
        public UserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AppUserRequest userRequest)
        {
            if (ModelState.IsValid)
            {
                await _appUserService.AddAsync(userRequest);

                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                var token = await _appUserService.LoginAsync(userLogin);
                Response.Cookies.Append("token", token, new CookieOptions { MaxAge = TimeSpan.FromHours(6) });
            }
            catch (NotFoundException ex)
            {
                ViewData["Message"] = ex.Message;
                return View();
            }
            catch (Unauthorized unauthorized)
            {
                ViewData["Message"] = unauthorized.Message;
                return View();
            }

            return RedirectToAction("Index", "Exam");

        }

        [HttpGet]
        public IActionResult LogOut()
        {
            Response.Cookies.Delete("token");
            return RedirectToAction("Index", "Home");
        }
    }
}
