using Microsoft.AspNetCore.Identity;
using SchoolApplication.Contracts.ViewModels;
using SchoolApplication.Data;
using SchoolApplication.Data.Models;
using SchoolApplication.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Logic.Services
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public RegisterUserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<ResponseDto<ApplicationUser>> RegisterNewAccountAsync(RegisterUserViewModel registerUserViewModel)
        {
            var user = new ApplicationUser
            {
                UserName = registerUserViewModel.Email,
                Email = registerUserViewModel.Email
            };

            var result = await userManager.CreateAsync(user, registerUserViewModel.Password);

            if (result.Succeeded)
            {
                return new ResponseDto<ApplicationUser>()
                {
                    Body = user
                };
            }
            else
            {
                return new ResponseDto<ApplicationUser>()
                {
                    Errors = result.Errors.Select(x => new ErrorModel() { Message = x.Description}).ToList()
                };
            }
        }

        public async Task SignIn(RegisterUserViewModel registerUserViewModel)
        {
            var user = new ApplicationUser
            {
                UserName = registerUserViewModel.Email,
                Email = registerUserViewModel.Email
            };
            await signInManager.SignInAsync(user, isPersistent: false);
        }
    }
}
