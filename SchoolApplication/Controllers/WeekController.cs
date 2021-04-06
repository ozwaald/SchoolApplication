using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Data;
using SchoolApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Controllers
{
    public class WeekController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
