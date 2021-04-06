using Microsoft.Extensions.DependencyInjection;
using SchoolApplication.Logic.Interfaces;
using SchoolApplication.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Logic
{
    public class LogicServicesContainer
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IGetTeacherInfo, GetTeacherInfo>();
            services.AddScoped<IGetTeachersList, GetTeachersList>();
            services.AddScoped<IManageStudentApplications, ManageStudentApplications>();
            services.AddScoped<IGetStudentInfo, GetStudentInfo>();
            services.AddScoped<IGetStudentsList, GetStudentsList>();
            services.AddScoped<IGetGroupsList, GetGroupsList>();
            services.AddScoped<IManageGroup, ManageGroup>();
            services.AddScoped<IGetTeacherApplicationsList, GetTeacherApplicationsList>();
            services.AddScoped<IGetStudentApplicationsList, GetStudentApplicationsList>();
            services.AddScoped<IGetLessonsList, GetLessonsList>();
            services.AddScoped<ICreateLesson, CreateLesson>();
            services.AddScoped<IRegisterUserService, RegisterUserService>();
            services.AddScoped<IUsersCounterService, UsersCounterService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ILogoutService, LogoutService>();
            services.AddScoped<IStudentApplicationService, StudentApplicationService>();
            services.AddScoped<ITeacherApplicationService, TeacherApplicationService>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}
