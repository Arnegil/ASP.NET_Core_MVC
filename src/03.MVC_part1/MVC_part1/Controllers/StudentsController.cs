using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_part1.Models;

namespace MVC_part1.Controllers
{
    public class StudentsController : Controller
    {
        private static readonly List<Student> Students = new List<Student>
        {
            new Student
            {
                Id = 0,
                FirstName = "Петр",
                MiddleName = "Петрович",
                LastName = "Петров",
                City = "Екатеринбург",
                BirthDate = new DateTime(1990, 04, 23),
                TabelNumber = 4927592
            }
        };
        
        public IActionResult Index()
        {
            return View(new StudentsModel{Students = Students});
        }
        
        public Student CreateStudent(Student student)
        {
            if (Students.Any(x => x.Id == student.Id))
                throw new Exception($"Already exists with id = {student.Id}");
            Students.Add(student);
            return student;
        }
        
        public Student GetStudent(int id)
        {
            if (!Students.Exists(x => x.Id == id))
                throw new Exception($"Not exists with id = {id}");
            return Students.Find(x => x.Id == id);
        }

        public Student UpdateStudent(Student student)
        {
            if (!Students.Exists(x => x.Id == student.Id))
                throw new Exception($"Not exists with id = {student.Id}");
            Students.RemoveAll(x => x.Id == student.Id);
            Students.Add(student);
            return student;
        }

        public string DeleteStudent(int id)
        {
            if (!Students.Exists(x => x.Id == id))
                throw new Exception($"Not exists with id = {id}");
            Students.RemoveAll(x => x.Id == id);
            return "Success delete!";
        }
    }
}
