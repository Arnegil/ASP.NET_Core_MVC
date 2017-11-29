using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_part1.DBModels;
using EF_part1.Interfaces;
using EF_part1.Models;

namespace EF_part1.Services
{
    public class StudentGenerator : IStudentGenerator
    {
        private readonly IStudentService _studentService;

        public StudentGenerator(IStudentService studentService)
        {
            if (studentService == null)
                throw new ArgumentNullException(nameof(studentService));

            _studentService = studentService;
        }

        public async Task<StudentsModelVM> GetStudentsModel()
        {
            return await Task.Run(async () => new StudentsModelVM
            {
                Students = (await _studentService.GetStudents()).Select(ConvertStudentToVM).OrderBy(x => x.FullName)
            });
        }

        public async Task<StudentVM> GetStudent(int studentId)
        {
            return ConvertStudentToVM(await _studentService.GetStudent(studentId));
        }

        public async Task<StudentVM> GetNewStudentModel()
        {
            return await Task.FromResult(new StudentVM());
        }

        private StudentVM ConvertStudentToVM(Student student)
        {
            return new StudentVM
            {
                Id = student.Id,
                BirthDate = student.BirthDate,
                City = student.City,
                FirstName = student.FirstName,
                LastName = student.LastName,
                MiddleName = student.MiddleName,
                Gender = student.Gender,
                TabelNumber = student.TabelNumber
            };
        }
    }
}
