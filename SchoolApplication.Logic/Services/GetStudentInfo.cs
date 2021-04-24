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
    public class GetStudentInfo : IGetStudentInfo
    {
        private readonly SchoolDbContext dbContext;
        private readonly IMapper mapper;

        public GetStudentInfo(SchoolDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<StudentInfoViewModel> StudentInfoAsync(string id)
        {
            var student = await dbContext.ApplicationUser.FirstOrDefaultAsync(s => s.ApplicationUserType == ApplicationUserType.Student && s.Id == id);

            var groupInfo = await dbContext.StudentInfos.FirstOrDefaultAsync(stud => stud.ApplicationUserId == student.Id);
            
            if (groupInfo != null)
            {
                var group = await dbContext.Groups.FirstOrDefaultAsync(gr => gr.Id == groupInfo.GroupId);

                return new StudentInfoViewModel
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    BirthDate = student.BirthDate,
                    Email = student.Email,
                    Gender = student.Gender,
                    PreviousGrade = student.Comments,
                    GroupName = group.Grade + " " + group.Name
                };
            }
            else
            {
                return new StudentInfoViewModel
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    BirthDate = student.BirthDate,
                    Email = student.Email,
                    Gender = student.Gender,
                    PreviousGrade = student.Comments,
                };
            }

        }
    }
}
