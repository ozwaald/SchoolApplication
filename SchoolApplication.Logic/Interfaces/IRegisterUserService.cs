using SchoolApplication.Contracts.ViewModels;
using SchoolApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Logic.Interfaces
{
    public interface IRegisterUserService
    {
        Task<ResponseDto<ApplicationUser>> RegisterNewAccountAsync(RegisterUserViewModel registerUserViewModel);
        Task SignIn(RegisterUserViewModel registerUserViewModel);
    }
}
