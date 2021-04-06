using SchoolApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Logic.Interfaces
{
    public interface IUsersCounterService
    {
        int GetCountOfStudentsFromDB();
        int GetCountOfTeachersFromDB();
        int GetCountOfStudentApplicationsFromDB();
        int GetCountOfTeacherApplicationsFromDB();
    }
}
