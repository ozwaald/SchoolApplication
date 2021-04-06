using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Data.Models
{
    public class StudentApplication : ApplicationModel
    {
        [Required]
        [Display(Name = "Previous Grade")]
        [Range(1, 11, ErrorMessage = "{0} must be between {1} and {2}.")]
        public int PreviousGrade { get; set; }

        public ApplicationUserType UserType = ApplicationUserType.Student;
    }
}
