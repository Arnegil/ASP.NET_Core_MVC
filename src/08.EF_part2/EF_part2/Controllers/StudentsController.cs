using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_part2.Extensions;
using EF_part2.Interfaces;
using EF_part2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace EF_part2.Controllers
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
        public async Task<IActionResult> CreateStudent(StudentVM student)
        {
            if (!ModelState.IsValid)
            {
                return await NewStudent();
            }

            var service = HttpContext.RequestServices.GetService<IStudentService>();
            int newStudentId = await service.AddStudent(student.ConvertStudentToDBModel());
            var createdStudent = await _studentGenerator.GetStudent(newStudentId);
            return View("ViewStudent", createdStudent);
        }

        [HttpGet]
        public async Task<IActionResult> ViewStudent(int id)
        {
            var student = await _studentGenerator.GetStudent(id);
            return View("ViewStudent", student);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStudent(StudentVM student)
        {
            if (!ModelState.IsValid)
            {
                return await EditStudent(student.Id);
            }

            var service = HttpContext.RequestServices.GetService<IStudentService>();
            int newStudentId = await service.UpdateStudent(student.ConvertStudentToDBModel());
            var createdStudent = await _studentGenerator.GetStudent(newStudentId);
            return RedirectToAction("ViewStudent", createdStudent);
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
