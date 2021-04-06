using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    public class StudentApplicationService : IStudentApplicationService
    {
        private readonly SchoolDbContext dbContext;
        private readonly IMapper mapper;

        public StudentApplicationService(SchoolDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task CreateStudentRequestAsync(StudentApplicationViewModel studentApplication)
        {
            var studApp = mapper.Map<StudentApplication>(studentApplication);

            await dbContext.StudentApplications.AddAsync(studApp);
            await dbContext.SaveChangesAsync();
        }
    }
}
