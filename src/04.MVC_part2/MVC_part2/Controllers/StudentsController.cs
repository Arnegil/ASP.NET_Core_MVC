using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MVC_part2.Data;
using Microsoft.AspNetCore.Mvc;
using MVC_part2.Models;

namespace MVC_part2.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View(new StudentsModel { Students = DataSource.Students });
        }
        
        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            if (DataSource.Students.Any(x => x.Id == student.Id))
                ModelState.AddModelError("Id", $"Already exists with id = {student.Id}");

            if (ModelState.IsValid)
            {
                DataSource.Students.Add(student);
                return Json(student);
            }

            return BadRequest(ModelState);
        }
        
        [HttpGet]
        public IActionResult GetStudent(int id)
        {
            if (!DataSource.Students.Exists(x => x.Id == id))
                ModelState.AddModelError("Id", $"Not exists with id = {id}");

            if (ModelState.IsValid)
            {
                var student = DataSource.Students.Find(x => x.Id == id);
                return Json(student);
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        public IActionResult UpdateStudent([FromBody] Student student)
        {
            if (!DataSource.Students.Exists(x => x.Id == student.Id))
                ModelState.AddModelError("Id", $"Not exists with id = {student.Id}");

            if (ModelState.IsValid)
            {
                DataSource.Students.RemoveAll(x => x.Id == student.Id);
                DataSource.Students.Add(student);
                return Json(student);
            }

            return BadRequest(ModelState);
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
