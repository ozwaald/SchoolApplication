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
    public class GetTeachersList : IGetTeachersList
    {
        private readonly SchoolDbContext dbContext;
        private readonly IMapper mapper;

        public GetTeachersList(SchoolDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<TeacherInfoViewModel>> TeachersListAsync()
        {
            List<ApplicationUser> teachers = await dbContext.ApplicationUser.Where(s => s.ApplicationUserType == ApplicationUserType.Teacher).ToListAsync();

            return mapper.Map<List<TeacherInfoViewModel>>(teachers);
        }
    }
}
