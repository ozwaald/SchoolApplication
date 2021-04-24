using SchoolApplication.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Logic.Interfaces
{
    public interface IManageGroup
    {
        Task CreateGroupAsync(GroupViewModel groupViewModel);
        Task Delete<T>(T entity) where T : class;
        Task AddStudentAsync(List<StudentInfoViewModel> viewModel);
    }
}
