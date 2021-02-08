using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Data.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public List<Course> Courses { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
