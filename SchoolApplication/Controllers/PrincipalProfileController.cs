using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolApplication.Contracts.ViewModels;
using SchoolApplication.Data;
using SchoolApplication.Data.Models;
using SchoolApplication.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Controllers
{
    [Authorize(Roles = "Principal")]
    public class PrincipalProfileController : Controller
    {
        private readonly SchoolDbContext dbContext;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IUsersCounterService usersCounter;
        private readonly ICreateLesson createLesson;
        private readonly IGetLessonsList getLessons;
        private readonly IGetStudentApplicationsList getStudentApplications;
        private readonly IGetTeacherApplicationsList getTeacherApplications;
        private readonly IGetGroupsList getGroups;
        private readonly IManageGroup manageGroup;
        private readonly IGetStudentsList studentsList;
        private readonly IGetStudentInfo studentInfo;
        private readonly IManageStudentApplications manageStudentApplications;
        private readonly IGetTeachersList teachersList;
        private readonly IGetTeacherInfo teacherInfo;

        public PrincipalProfileController(SchoolDbContext dbContext, IMapper mapper,
                                          UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
                                          IUsersCounterService usersCounter, ICreateLesson createLesson,
                                          IGetLessonsList getLessons, IGetStudentApplicationsList getStudentApplications,
                                          IGetTeacherApplicationsList getTeacherApplications, IGetGroupsList getGroups,
                                          IManageGroup manageGroup, IGetStudentsList studentsList, IGetStudentInfo studentInfo,
                                          IManageStudentApplications manageStudentApplications,
                                          IGetTeachersList teachersList, IGetTeacherInfo teacherInfo)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.usersCounter = usersCounter;
            this.createLesson = createLesson;
            this.getLessons = getLessons;
            this.getStudentApplications = getStudentApplications;
            this.getTeacherApplications = getTeacherApplications;
            this.getGroups = getGroups;
            this.manageGroup = manageGroup;
            this.studentsList = studentsList;
            this.studentInfo = studentInfo;
            this.manageStudentApplications = manageStudentApplications;
            this.teachersList = teachersList;
            this.teacherInfo = teacherInfo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new PrincipalProfileViewModel
            {
                StudentsApplicationsCount = usersCounter.GetCountOfStudentApplicationsFromDB(),
                StudentsCount = usersCounter.GetCountOfStudentsFromDB(),
                TeachersApplicationsCount = usersCounter.GetCountOfTeacherApplicationsFromDB(),
                TeachersCount = usersCounter.GetCountOfTeachersFromDB()
            };
            return View("PrincipalProfile", model);
        }

        [HttpGet]
        public async Task<IActionResult> LessonsList()
        {
            var result = await getLessons.LessonsAsync();

            return View(result);
        }

        [HttpGet]
        public IActionResult CreateNewLesson()
        {
            return View(new LessonTypeViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewLesson(LessonTypeViewModel lessonTypeViewModel)
        {
            await createLesson.CreateLessonAsync(lessonTypeViewModel);

            return RedirectToAction(nameof(LessonsList), "PrincipalProfile");
        }

        [HttpGet]
        public async Task<IActionResult> StudentApplicationsList()
        {
            var result = await getStudentApplications.StudentApplicationsAsync();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> TeacherApplicationsList()
        {

            var result = await getTeacherApplications.TeacherApplicationsAsync();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Groups()
        {
            var result = await getGroups.GroupsAsync();

            return View(result);
        }

        [HttpGet]
        public IActionResult CreateNewGroup()
        {
            return View(new GroupViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewGroup(GroupViewModel groupViewModel)
        {
            await manageGroup.CreateGroupAsync(groupViewModel);

            return RedirectToAction(nameof(Groups), "PrincipalProfile");
        }

        [HttpGet]
        public async Task<IActionResult> GroupInfo(int id, int grade)
        {
            var groupVM = new GroupViewModel();

            groupVM.Id = id;
            groupVM.Grade = grade;

            foreach (var stud in await userManager.Users.Where(s => s.ApplicationUserType == ApplicationUserType.Student && s.Status == false).ToListAsync())
            {
                var studentViewModel = new StudentInfoViewModel
                {
                    Id = stud.Id,
                    FirstName = stud.FirstName,
                    LastName = stud.LastName,
                    Email = stud.Email,
                    PreviousGrade = stud.Comments,
                    IsSelected = stud.Status
                };

                groupVM.Students.Add(studentViewModel);
            }

            ViewBag.Students = groupVM.Students.Where(s => s.PreviousGrade == groupVM.Grade.ToString()).Select(s => new SelectListItem()
            {
                Text = s.FirstName + " " + s.LastName + ", Previous grade: " + s.PreviousGrade,
                Value = s.Id
            }).ToList();

            return View(groupVM);
        }

        [HttpPost]
        public async Task<IActionResult> GroupInfo(GroupViewModel groupVM)
        {
            var student = await userManager.FindByIdAsync(groupVM.StudentId);

            var studentVM = new StudentInfoViewModel
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                PreviousGrade = student.Comments
            };

            groupVM.Students.Add(studentVM);

            var studentInfo = new StudentInfo
            {
                ApplicationUserId = studentVM.Id,
                GroupId = groupVM.Id,
                IsSelected = true
            };

            var user = await userManager.FindByIdAsync(student.Id);

            user.Status = true;
            await userManager.UpdateAsync(user);

            await dbContext.StudentInfos.AddAsync(studentInfo);
            await dbContext.SaveChangesAsync();
           
            return RedirectToAction(nameof(GroupInfo), "PrincipalProfile");
        }


        [HttpGet]
        public IActionResult ManageStudentApplication(int id)
        {
            var student = dbContext.StudentApplications.FirstOrDefault(u => u.Id == id);

            var map = mapper.Map<ManageStudentApplicationViewModel>(student);

            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveStudentApplication(ManageStudentApplicationViewModel viewModel)
        {
            var studentApplication = dbContext.StudentApplications.FirstOrDefault(u => u.Id == viewModel.Id);

            var hasher = new PasswordHasher<ApplicationUser>();

            var student = new ApplicationUser
            {
                FirstName = studentApplication.FirstName,
                LastName = studentApplication.LastName,
                BirthDate = studentApplication.BirthDate,
                Gender = studentApplication.Gender,
                Comments = studentApplication.PreviousGrade.ToString(),
                Email = studentApplication.Email,
                EmailConfirmed = true,
                UserName = studentApplication.Email,
                PasswordHash = hasher.HashPassword(null, "Student70+"),
                NormalizedUserName = studentApplication.Email.ToUpper(),
                NormalizedEmail = studentApplication.Email.ToUpper(),
                ApplicationUserType = ApplicationUserType.Student,
                Status = false
            };

            await dbContext.ApplicationUser.AddAsync(student);

            dbContext.StudentApplications.Remove(studentApplication);

            await dbContext.SaveChangesAsync();

            var stud = await dbContext.ApplicationUser.FirstOrDefaultAsync(s => s.ApplicationUserType == ApplicationUserType.Student && s.Email == student.Email);

            //var role = roleManager.FindByNameAsync("Student");

            await userManager.AddToRoleAsync(stud, "Student");

            //await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(StudentApplicationsList), "PrincipalProfile");
        }

        public async Task<IActionResult> DeclineStudentApplication()
        {
            var studentApplication = dbContext.StudentApplications.FirstOrDefault();

            dbContext.StudentApplications.Remove(studentApplication);

            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(StudentApplicationsList), "PrincipalProfile");
        }

        [HttpGet]
        public IActionResult ManageTeacherApplication(int id)
        {
            var teacher = dbContext.TeacherApplications.FirstOrDefault(u => u.Id == id);

            var map = mapper.Map<ManageTeacherApplicationViewModel>(teacher);

            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveTeacherApplication(int id)
        {
            var teacherApplication = dbContext.TeacherApplications.FirstOrDefault(u => u.Id == id);

            var hasher = new PasswordHasher<ApplicationUser>();

            var teacher = new ApplicationUser
            {
                FirstName = teacherApplication.FirstName,
                LastName = teacherApplication.LastName,
                BirthDate = teacherApplication.BirthDate,
                Gender = teacherApplication.Gender,
                Email = teacherApplication.Email,
                Comments = teacherApplication.Specialization,
                EmailConfirmed = true,
                UserName = teacherApplication.Email,
                PasswordHash = hasher.HashPassword(null, "Teacher70+"),
                NormalizedUserName = teacherApplication.Email.ToUpper(),
                NormalizedEmail = teacherApplication.Email.ToUpper(),
                ApplicationUserType = ApplicationUserType.Teacher,
                Status = false
            };

            await dbContext.ApplicationUser.AddAsync(teacher);

            dbContext.TeacherApplications.Remove(teacherApplication);

            await dbContext.SaveChangesAsync();

            var teach = await dbContext.ApplicationUser.FirstOrDefaultAsync(s => s.ApplicationUserType == ApplicationUserType.Teacher && s.Email == teacher.Email);

            await userManager.AddToRoleAsync(teach, "Teacher");

            return RedirectToAction(nameof(TeacherApplicationsList), "PrincipalProfile");
        }

        [HttpPost]
        public async Task<IActionResult> DeclineTeacherApplication()
        {
            var teacherApplication = dbContext.TeacherApplications.FirstOrDefault();

            dbContext.TeacherApplications.Remove(teacherApplication);

            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(TeacherApplicationsList), "PrincipalProfile");
        }

        [HttpGet]
        public async Task<IActionResult> StudentsList()
        {
            var result = await studentsList.StudentsListAsync();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> StudentInfo(string id)
        {
            var student = await studentInfo.StudentInfoAsync(id);

            return View(student);
        }

        [HttpGet]
        public async Task<IActionResult> TeachersList()
        {
            var result = await teachersList.TeachersListAsync();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> TeacherInfo(string id)
        {
            var teacher = await teacherInfo.TeacherInfoAsync(id);

            return View(teacher);
        }

    }
}
