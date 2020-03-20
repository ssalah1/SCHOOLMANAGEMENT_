using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OodweyneMadrasa.Models;

namespace OodweyneMadrasa.Controllers
{
    public class TeacherController : Controller
    {
        private readonly SchoolDatabase _db;
        public TeacherController(SchoolDatabase db)
        {
            _db = db;  
        }

        public IActionResult AllTeachers()
        {
            var showAllTeachers = _db.Teachers.Include(s => s.Students).ToList();
            return View(showAllTeachers);
        }
        public IActionResult CreateTeacher()
        {
            return View();
        }
       
    }
}