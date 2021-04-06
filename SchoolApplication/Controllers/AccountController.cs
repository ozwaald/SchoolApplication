using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Contracts.ViewModels;
using SchoolApplication.Data.Models;
using SchoolApplication.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRegisterUserService registerUserService;
        private readonly ILogoutService logoutService;
        private readonly ILoginService loginService;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(IRegisterUserService registerUserService, ILogoutService logoutService, ILoginService loginService, SignInManager<ApplicationUser> signInManager)
        {
            this.registerUserService = registerUserService;
            this.logoutService = logoutService;
            this.loginService = loginService;
            this.signInManager = signInManager;
        }

        /* Register is only for testing. Later it will be removed*/

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel registerUserViewModel)
        {
            var result = await registerUserService.RegisterNewAccountAsync(registerUserViewModel);

            if (!result.HasErrors)
            {
                await registerUserService.SignIn(registerUserViewModel);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Message);
                }
                return View(registerUserViewModel);
            }

            return RedirectToAction("Index", "Home");
        }



        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await logoutService.LogoutAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var result = await loginService.LoginToAccountAsync(loginViewModel);

            if (!result.HasErrors)
            {
                await signInManager.PasswordSignInAsync(result.Body, loginViewModel.Password, isPersistent: loginViewModel.RememberMe, false);

                if (result.Body.ApplicationUserType == ApplicationUserType.Principal)
                {
                    return RedirectToAction("Index", "PrincipalProfile");
                }
                else if (User.IsInRole("Student"))
                {
                    return RedirectToAction("Index", "StudentProfile");
                }
                else if (User.IsInRole("Teacher"))
                {
                    return RedirectToAction("Index", "TeacherProfile");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Message);
                }
                return View(loginViewModel);
            }
        }
    }
}
