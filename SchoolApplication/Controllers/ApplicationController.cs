using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Contracts.ViewModels;
using SchoolApplication.Data;
using SchoolApplication.Data.Models;
using SchoolApplication.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApplication.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly IStudentApplicationService studentAppService;
        private readonly ITeacherApplicationService teacherAppService;

        public ApplicationController(IStudentApplicationService studentAppService, ITeacherApplicationService teacherAppService)
        {
            this.studentAppService = studentAppService;
            this.teacherAppService = teacherAppService;
        }

        [HttpGet]
        public IActionResult StudentApplicationForm()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TeacherApplicationForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> StudentApplicationForm(StudentApplicationViewModel studentApplication)
        {
            if (!ModelState.IsValid)
            {
                return View(studentApplication);
            }

            await studentAppService.CreateStudentRequestAsync(studentApplication);

            return RedirectToAction("RequestComplete");
        }

        [HttpPost]
        public async Task<IActionResult> TeacherApplicationForm(TeacherApplicationViewModel teacherApplication)
        {
            if (!ModelState.IsValid)
            {
                return View(teacherApplication);
            }

            await teacherAppService.CreateTeacherRequestAsync(teacherApplication);

            return RedirectToAction("RequestComplete");
        }

        public IActionResult RequestComplete()
        {
            ViewBag.RequestCompleteMessage = "Thank you for applying. Your application will be reviewed in 5-7 working days.";
            return View();
        }
    }
}
