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
        public int Id { get; set; }

        public int Grade { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}
