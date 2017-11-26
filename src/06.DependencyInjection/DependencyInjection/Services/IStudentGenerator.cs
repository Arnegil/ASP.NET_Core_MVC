using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjection.Models;

namespace DependencyInjection.Services
{
    public interface IStudentGenerator
    {
        Task<StudentsModel> GetStudentsModel();
        Task<Student> GetStudent(int studentId);
        Task<Student> GetNewStudentModel();
    }

    public class StudentGenerator : IStudentGenerator
    {
        private readonly IStudentService _studentService;

        public StudentGenerator(IStudentService studentService)
        {
            if (studentService == null)
                throw new ArgumentNullException(nameof(studentService));

            _studentService = studentService;
        }

        public async Task<StudentsModel> GetStudentsModel()
        {
            return await Task.Run(async () => new StudentsModel
            {
                Students = (await _studentService.GetStudents()).OrderBy(x => x.FullName)
            });
        }

        public async Task<Student> GetStudent(int studentId)
        {
            return await _studentService.GetStudent(studentId);
        }

        public async Task<Student> GetNewStudentModel()
        {
            return await Task.FromResult(new Student());
        }
    }
}
