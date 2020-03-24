using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OodweyneMadrasa.Models;

namespace OodweyneMadrasa.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly SchoolDatabase _db;
        public SubjectsController(SchoolDatabase db)
        {
            _db = db;
        }
        public IActionResult AllSubjects()
        {
            var showAllSubjects = _db.Subjects.Include(s => s.Students).ToList();
            return View(showAllSubjects);
        }


        public IActionResult CreateSubject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSubject(Subject subject)
        {
            if (ModelState.IsValid)
            {
                _db.Subjects.Add(subject);
                _db.SaveChanges();
                return RedirectToAction("AllSubjects");
            }

            return View(subject);
        }

        public IActionResult EditSubject(int Id)
        {
            var subject = _db.Subjects.Find(Id);
            if (subject == null)
            {
                return NotFound("Subject Not Found");
            }
            return View(subject);
        }

        [HttpPost]
        public IActionResult EditSubject(Subject newSubject)
        {
            if (ModelState.IsValid)
            {
                _db.Subjects.Update(newSubject);
                _db.SaveChanges();
                return RedirectToAction("AllSubjects");
            }
            return View(newSubject);
        }

        public IActionResult DeleteSubject(int Id)
        {
            var subject = _db.Subjects.Find(Id);
            if (subject == null)
            {
                return NotFound("Teacher not found");
            }
            _db.Subjects.Remove(subject);
            _db.SaveChanges();
            return RedirectToAction("AllSubjects");
        }
    }
}