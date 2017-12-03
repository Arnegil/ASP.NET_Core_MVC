using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_part1.DBModels;
using EF_part1.Interfaces;

namespace EF_part1.Services
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

        private async Task<int> GetNewModelId()
        {
            return await Task.FromResult(_context.Students.Any() ? _context.Students.Max(x => x.Id) + 1 : 0);
        }

        public async Task<int> AddStudent(StudentDBModel student)
        {
            return await Task.Run(async () =>
            {
                student.Id = await GetNewModelId();
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
                    _context.Students.Remove(student);
                _context.SaveChanges();
            });
        }

        public async Task UpdateStudent(StudentDBModel newStudent)
        {
            await Task.Run(() =>
            {
                var oldStudent = _context.Students.FirstOrDefault(x => x.Id == newStudent.Id);
                if (oldStudent != null)
                {
                    _context.Students.Remove(oldStudent);
                    _context.SaveChanges();
                    _context.Students.Add(newStudent);
                    _context.SaveChanges();
                }
            });
        }
    }
}
