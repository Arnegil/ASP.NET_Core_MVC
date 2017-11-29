using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_part1.DBModels;
using EF_part1.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace EF_part1.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentGenerator _studentGenerator;

        public StudentsController(IStudentGenerator studentGenerator)
        {
            if (studentGenerator == null)
                throw new ArgumentNullException(nameof(studentGenerator));

            _studentGenerator = studentGenerator;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _studentGenerator.GetStudentsModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return await NewStudent();
            }

            var service = HttpContext.RequestServices.GetService<IStudentService>();
            await service.AddStudent(student);
            var createdStudent = await _studentGenerator.GetStudent(student.Id);
            return View("ViewStudent", createdStudent);
        }

        [HttpGet]
        public async Task<IActionResult> ViewStudent(int id)
        {
            var student = await _studentGenerator.GetStudent(id);
            return View("ViewStudent", student);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return await EditStudent(student.Id);
            }

            var service = HttpContext.RequestServices.GetService<IStudentService>();
            await service.UpdateStudent(student);
            return RedirectToAction("ViewStudent", student);
        }

        [HttpGet]
        public async Task<IActionResult> NewStudent()
        {
            var student = await _studentGenerator.GetNewStudentModel();
            return View("CreateStudent", student);
        }

        [HttpGet]
        public async Task<IActionResult> EditStudent(int id)
        {
            var student = await _studentGenerator.GetStudent(id);
            return View("EditStudent", student);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var service = HttpContext.RequestServices.GetService<IStudentService>();
            await service.RemoveStudent(id);
            return View("Index", await _studentGenerator.GetStudentsModel());
        }
    }
}
