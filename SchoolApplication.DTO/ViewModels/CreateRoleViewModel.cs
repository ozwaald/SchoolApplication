using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Contracts.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }
    }
}
