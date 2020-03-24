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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTeacher(Teacher newTeacher)
        {
            if (ModelState.IsValid)
            {
                _db.Teachers.Add(newTeacher);
                _db.SaveChanges();

                return RedirectToAction("AllTeachers");
            }
            return View(newTeacher);
        }
        public IActionResult EditTeacher(int Id)
        {
            var teacher = _db.Teachers.Find(Id);
            if (teacher == null)
            {
                return NotFound("Teacher Not Found");
            }
            return View(teacher);
        }
        [HttpPost]
        public IActionResult EditTeacher(Teacher newTeacher)
        {
            if (ModelState.IsValid)
            {
                _db.Teachers.Update(newTeacher);
                _db.SaveChanges();

                return RedirectToAction("AllTeachers");
            }
            return View(newTeacher);
        }
        public IActionResult DeleteTeacher(int Id)
        {
            var teacher = _db.Teachers.Find(Id);
            if (teacher == null)
            {
                return NotFound("Teacher Not Found");
            }
            _db.Teachers.Remove(teacher);
            _db.SaveChanges();
            return RedirectToAction("AllTeachers");
        }
    }
}