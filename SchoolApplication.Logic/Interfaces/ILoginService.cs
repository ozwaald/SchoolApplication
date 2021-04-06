using SchoolApplication.Contracts.ViewModels;
using SchoolApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Logic.Interfaces
{
    public interface ILoginService
    {
        Task<ResponseDto<ApplicationUser>> LoginToAccountAsync(LoginViewModel loginViewModel);
    }
}
