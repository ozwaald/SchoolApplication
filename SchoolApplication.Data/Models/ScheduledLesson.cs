using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Data.Models
{
    public class ScheduledLesson
    {
        public int Id { get; set; }

        public int LessonTypeId { get; set; }
        public LessonType LessonType { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int TeacherId { get; set; }
        public TeacherInfo Teacher { get; set; }
    }
}
