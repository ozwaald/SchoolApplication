using SchoolApplication.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Logic.Interfaces
{
    public interface ICreateLesson
    {
        Task CreateLessonAsync(LessonTypeViewModel lessonTypeViewModel);
    }
}
