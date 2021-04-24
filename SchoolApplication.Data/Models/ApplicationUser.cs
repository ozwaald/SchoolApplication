using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public ApplicationUserType ApplicationUserType { get; set; }

        [StringLength(50)]
        public string Comments { get; set; }

        public StudentInfo StudentInfo { get; set; }

        public TeacherInfo TeacherInfo { get; set; }

        public PrincipalInfo PrincipalInfo { get; set; }

        public bool Status { get; set; }
    }
}
