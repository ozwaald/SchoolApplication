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
    public class GetLessonsList : IGetLessonsList
    {
        private readonly IMapper mapper;
        private readonly SchoolDbContext dbContext;

        public GetLessonsList(IMapper mapper, SchoolDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<LessonTypeViewModel>> LessonsAsync()
        {
            List<LessonType> lessons = await dbContext.LessonTypes.ToListAsync();

            return mapper.Map<List<LessonTypeViewModel>>(lessons);
        }
    }
}
