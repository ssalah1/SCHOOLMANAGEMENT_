using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OodweyneMadrasa.Models;

namespace OodweyneMadrasa.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolDatabase _db;
        public StudentsController(SchoolDatabase db)
        {
                _db = db;
        }
        public IActionResult AllStudents()
        {
            var students = _db.Students.Include(t => t.Teacher).Include(s => s.Subject).ToList();
            return View(students);
        }
        public IActionResult CreateStudent()
        {
            ViewBag.Courses = _db.Subjects.ToList();
            ViewBag.Teachers = _db.Teachers.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Add(student);
                _db.SaveChanges();
                return RedirectToAction("AllStudents");
            }
            return View(student);
        }

        public IActionResult EditStudent(int Id)
        {
            var student = _db.Students.Find(Id);
            if (student == null)
            {
                return NotFound("Student Not Found");
            }
            ViewBag.Courses = _db.Subjects.ToList();
            ViewBag.Teachers = _db.Teachers.ToList();
            return View(student);
        }
        [HttpPost]
        public IActionResult EditStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Update(student);
                _db.SaveChanges();
                return RedirectToAction("AllStudents");
            }
            return View(student);
        }
        public IActionResult DeleteStudent(int Id)
        {
            var student = _db.Students.Find(Id);
            if (student == null)
            {
                return NotFound("Student Not Found");
            }
            _db.Students.Remove(student);
            _db.SaveChanges();
            return RedirectToAction("AllStudents");
        }
    }
}