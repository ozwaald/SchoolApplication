using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Contracts.ViewModels
{
    public class PrincipalProfileViewModel
    {
        public int StudentsApplicationsCount { get; set; }
        public int TeachersApplicationsCount { get; set; }
        public int StudentsCount { get; set; }
        public int TeachersCount { get; set; }
    }
}
