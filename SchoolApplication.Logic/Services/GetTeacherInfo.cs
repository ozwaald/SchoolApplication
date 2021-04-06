using Microsoft.EntityFrameworkCore;
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
    public class GetTeacherInfo : IGetTeacherInfo
    {
        private readonly SchoolDbContext dbContext;

        public GetTeacherInfo(SchoolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<TeacherInfoViewModel> TeacherInfoAsync(string id)
        {
            var teacher = await dbContext.ApplicationUser.FirstOrDefaultAsync(s => s.ApplicationUserType == ApplicationUserType.Teacher && s.Id == id);

            var teach = new TeacherInfoViewModel
            {
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                BirthDate = teacher.BirthDate,
                Email = teacher.Email,
                Gender = teacher.Gender,
                Specialization = teacher.Comments
            };

            return teach;
        }
    }
}
