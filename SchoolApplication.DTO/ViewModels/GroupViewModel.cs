using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Contracts.ViewModels
{
    public class GroupViewModel
    {
        public GroupViewModel()
        {
            Students = new List<StudentInfoViewModel>();
        }

        public int Id { get; set; }

        public int Grade { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public List<StudentInfoViewModel> Students { get; set; }

        public string StudentId { get; set; }
    }
}
