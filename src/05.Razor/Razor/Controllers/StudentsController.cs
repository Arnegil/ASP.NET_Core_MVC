using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Razor.Data;
using Razor.Models;

namespace Razor.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View(new StudentsModel { Students = DataSource.Students.OrderBy(x => x.FullName) });
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return NewStudent();
            }
            
            student.Id = DataSource.Students.Max(x => x.Id) + 1;
            DataSource.Students.Add(student);
            var createdStudent = DataSource.Students.FirstOrDefault(x => x.Id == student.Id);
            return View("ViewStudent", createdStudent);
        }

        [HttpGet]
        public IActionResult ViewStudent(int id)
        {
            var student = DataSource.Students.Find(x => x.Id == id);
            return View("ViewStudent", student);
        }

        [HttpPost]
        public IActionResult UpdateStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return EditStudent(student.Id);
            }
            
            DataSource.Students.RemoveAll(x => x.Id == student.Id);
            DataSource.Students.Add(student);
            return RedirectToAction("ViewStudent", student);
        }

        [HttpGet]
        public IActionResult NewStudent()
        {
            var student = new Student();
            return View("CreateStudent", student);
        }

        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            var student = DataSource.Students.Find(x => x.Id == id);
            return View("EditStudent", student);
        }

        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            if (!DataSource.Students.Exists(x => x.Id == id))
                ModelState.AddModelError("Id", $"Not exists with id = {id}");

            if (ModelState.IsValid)
            {
                DataSource.Students.RemoveAll(x => x.Id == id);
                return new ObjectResult("Success deleted!");
            }

            return BadRequest(ModelState);
        }
    }
}
