using AutoMapper;
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
    public class TeacherApplicationService : ITeacherApplicationService
    {
        private readonly SchoolDbContext dbContext;
        private readonly IMapper mapper;

        public TeacherApplicationService(SchoolDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task CreateTeacherRequestAsync(TeacherApplicationViewModel teacherApplication)
        {
            var teacherApp = mapper.Map<TeacherApplication>(teacherApplication);

            await dbContext.TeacherApplications.AddAsync(teacherApp);
            await dbContext.SaveChangesAsync();
        }
    }
}
