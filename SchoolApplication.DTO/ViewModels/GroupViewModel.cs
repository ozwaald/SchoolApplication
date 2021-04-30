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

        [Required(ErrorMessage = "Please enter the grade of group")]
        public int Grade { get; set; }
        
        [Required(ErrorMessage = "Please enter the name og group")]
        [StringLength(50)]
        public string Name { get; set; }
        public List<StudentInfoViewModel> Students { get; set; }

        public string StudentId { get; set; }
    }
}
