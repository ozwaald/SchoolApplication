using SchoolApplication.Data;
using SchoolApplication.Data.Models;
using SchoolApplication.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Logic.Services
{
    public class UsersCounterService : IUsersCounterService
    {
        private readonly SchoolDbContext dbContext;

        public UsersCounterService(SchoolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int GetCountOfStudentApplicationsFromDB()
        {
            var count = (from c in dbContext.StudentApplications
                         select c).Count();
            return count;
        }

        public int GetCountOfStudentsFromDB()
        {
            return dbContext.ApplicationUser.Where(s => s.ApplicationUserType == ApplicationUserType.Student).Count();
        }

        public int GetCountOfTeacherApplicationsFromDB()
        {
            return dbContext.TeacherApplications.Count();
        }

        public int GetCountOfTeachersFromDB()
        {
            return dbContext.ApplicationUser.Where(t => t.ApplicationUserType == ApplicationUserType.Teacher).Count();
        }
    }
}
