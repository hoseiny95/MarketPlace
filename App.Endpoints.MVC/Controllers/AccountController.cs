using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dtos.Users;
using App.Endpoints.MVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using Microsoft.AspNetCore.Identity;
using App.Domain.Core.Entities.Users;

namespace App.Endpoints.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAppUserService _userService;
        private readonly IMapper _mapper;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(IAppUserService userService, IMapper mapper,
            SignInManager<AppUser> signInManager)
        {
            _userService = userService;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model,CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Create(_mapper.Map<AppUserDto>(model), cancellationToken);
                if (result.Succeeded)
                {
                    return LocalRedirect("/Home/Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item.Description);
                        return View(model);
                    }
                }
            }
            return View(model);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model,CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Login(_mapper.Map<AppUserDto>(model), cancellationToken);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "نام کاربری یا کلمه عبور اشتباه است *");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
