using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Configurations.DBModels;
using Configurations.Interfaces;

namespace Configurations.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentDbContext _context;

        public StudentService(StudentDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public async Task<IEnumerable<StudentDBModel>> GetStudents()
        {
            return await Task.FromResult(_context.Students.ToList());
        }

        public async Task<StudentDBModel> GetStudent(int studentId)
        {
            return await Task.FromResult(_context.Students.FirstOrDefault(x => x.Id == studentId));
        }
        
        public async Task<int> AddStudent(StudentDBModel student)
        {
            return await Task.Run(() =>
            {
                _context.Students.Add(student);
                _context.SaveChanges();

                return student.Id;
            });
        }

        public async Task RemoveStudent(int studentId)
        {
            await Task.Run(() =>
            {
                var student = _context.Students.FirstOrDefault(x => x.Id == studentId);
                if (student != null)
                {
                    _context.Students.Remove(student);
                    _context.SaveChanges();
                }
            });
        }

        public async Task<int> UpdateStudent(StudentDBModel newStudent)
        {
            return await Task.Run(() =>
            {
                var oldStudent = _context.Students.FirstOrDefault(x => x.Id == newStudent.Id);
                if (oldStudent != null)
                {
                    oldStudent.FirstName = newStudent.FirstName;
                    oldStudent.LastName = newStudent.LastName;
                    oldStudent.MiddleName = newStudent.MiddleName;
                    oldStudent.BirthDate = newStudent.BirthDate;
                    oldStudent.City = newStudent.City;
                    oldStudent.Gender = newStudent.Gender;
                    oldStudent.TabelNumber = newStudent.TabelNumber;
                    
                    _context.SaveChanges();
                }

                return newStudent.Id;
            });
        }
    }
}
