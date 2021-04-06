using Microsoft.AspNetCore.Identity;
using SchoolApplication.Data.Models;
using SchoolApplication.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Logic.Services
{
    public class LogoutService : ILogoutService
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public LogoutService(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
