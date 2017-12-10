using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_part2.Extensions;
using EF_part2.Interfaces;
using EF_part2.Models;

namespace EF_part2.Services
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
                Students = (await _studentService.GetStudents()).Select(x => x.ConvertStudentToVM()).OrderBy(x => x.FullName)
            });
        }

        public async Task<StudentVM> GetStudent(int studentId)
        {
            return (await _studentService.GetStudent(studentId)).ConvertStudentToVM();
        }

        public async Task<StudentVM> GetNewStudentModel()
        {
            return await Task.FromResult(new StudentVM());
        }

    }
}
