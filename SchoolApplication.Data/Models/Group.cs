using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.Data.Models
{
    public class Group
    {
        public int Id { get; set; }

        public int Grade { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Homework { get; set; }

        public List<ScheduledLesson> Lessons { get; set; }

        public List<StudentInfo> Students { get; set; }
    }
}