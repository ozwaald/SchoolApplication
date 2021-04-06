using SchoolApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Contracts.ViewModels
{
    public class TeacherInfoViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public string Email { get; set; }

        public string Specialization { get; set; }

        public Group Group { get; set; }
    }
}
