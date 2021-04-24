using AutoMapper;
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
    public class GetStudentsList : IGetStudentsList
    {
        private readonly SchoolDbContext dbContext;
        private readonly IMapper mapper;

        public GetStudentsList(SchoolDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<StudentInfoViewModel>> StudentsListAsync()
        {
            List<ApplicationUser> students = await dbContext.ApplicationUser.Where(s => s.ApplicationUserType == ApplicationUserType.Student).ToListAsync();


            return mapper.Map<List<StudentInfoViewModel>>(students);
        }
    }
}
