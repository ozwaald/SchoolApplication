using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.Data.Models
{
    public class LessonType
    {
        public int Id { get; set; }
        
        [StringLength(50)]
        public string Name { get; set; }
        public int Grade { get; set; }
    }
}