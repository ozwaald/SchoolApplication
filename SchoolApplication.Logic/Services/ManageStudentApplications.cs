using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolApplication.Contracts.ViewModels;
using SchoolApplication.Data;
using SchoolApplication.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Logic.Services
{
    public class ManageStudentApplications : IManageStudentApplications
    {
        private readonly SchoolDbContext dbContext;
        private readonly IMapper mapper;

        public ManageStudentApplications(SchoolDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public Task ApproveStudentAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeclineStudentAsync()
        {
            throw new NotImplementedException();
        }

        public async Task GetStudentApplicationAsync(int id)
        {
            var student = await dbContext.StudentApplications.FirstOrDefaultAsync(u => u.Id == id);

            var map = mapper.Map<ManageStudentApplicationViewModel>(student);
        }

        //public async Task GetStudentRequestAsync(int id)
        //{
        //    var student = dbContext.StudentApplications.FirstOrDefault(u => u.Id == id);

        //    return mapper.Map<ManageStudentApplicationsViewModel>(student);
        //}
    }
}
