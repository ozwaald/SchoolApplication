using SchoolApplication.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Logic.Interfaces
{
    public interface IManageStudentApplications
    {
        Task GetStudentApplicationAsync(int id);
        Task ApproveStudentAsync();
        Task DeclineStudentAsync();
    }
}
