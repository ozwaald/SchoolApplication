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
    public class GetTeacherApplicationsList : IGetTeacherApplicationsList
    {
        private readonly SchoolDbContext dbContext;
        private readonly IMapper mapper;

        public GetTeacherApplicationsList(SchoolDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<TeacherApplicationViewModel>> TeacherApplicationsAsync()
        {
            List<TeacherApplication> teacherApplications = await dbContext.TeacherApplications.ToListAsync();

            return mapper.Map<List<TeacherApplicationViewModel>>(teacherApplications);
        }
    }
}
