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
    public class CreateLesson : ICreateLesson
    {
        private readonly SchoolDbContext dbContext;
        private readonly IMapper mapper;

        public CreateLesson(SchoolDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task CreateLessonAsync(LessonTypeViewModel lessonType)
        {
            var lessons = mapper.Map<LessonType>(lessonType);

            await dbContext.LessonTypes.AddAsync(lessons);
            await dbContext.SaveChangesAsync();
        }
    }
}
