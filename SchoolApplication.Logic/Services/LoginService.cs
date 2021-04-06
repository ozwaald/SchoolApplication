using Microsoft.AspNetCore.Identity;
using SchoolApplication.Contracts.ViewModels;
using SchoolApplication.Data.Models;
using SchoolApplication.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Logic.Services
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public LoginService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<ResponseDto<ApplicationUser>> LoginToAccountAsync(LoginViewModel loginViewModel)
        {
                      

            var user = await userManager.FindByEmailAsync(loginViewModel.Email);

            if (user == null)
            {
                var response = new ResponseDto<ApplicationUser>();
                response.Errors.Add(new ErrorModel() { Message = "Account doesn't exist." });
                
                return response;
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, loginViewModel.Password, false);

            if (result.Succeeded)
            {
                return new ResponseDto<ApplicationUser>()
                {
                    Body = user
                };
            }
            else
            {
                var response = new ResponseDto<ApplicationUser>();
                response.Errors.Add(new ErrorModel() { Message = "Incorrect password." });

                return response;
            }
        }
    }
}
