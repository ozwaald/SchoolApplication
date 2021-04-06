using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Data.Models
{
    public class TeacherApplication : ApplicationModel
    {
        [Required(ErrorMessage = "Please enter your specialization")]
        [Display(Name = "Specialization")]
        [StringLength(50)]
        public string Specialization { get; set; }

        public ApplicationUserType UserType = ApplicationUserType.Teacher;
    }
}
