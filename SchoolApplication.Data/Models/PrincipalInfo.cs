using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.Data.Models
{
    public class PrincipalInfo
    {
        public int Id { get; set; }

        [StringLength(450)]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}