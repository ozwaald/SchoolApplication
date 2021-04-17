using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Contracts.ViewModels
{
    public class UserRoleViewModel
    {
        public string ApplicationUserId { get; set; }
        public string ApplicationUserName { get; set; }
        public string UserFullName { get; set; }
        public bool IsSelected { get; set; }
    }
}
