using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjection.Models;

namespace DependencyInjection.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int studentId);
        Task<int> GetNewModelId();
        Task CreateNewStudent(Student student);
        Task RemoveStudent(int studentId);
        Task AddStudent(Student student);
    }

    public class StudentService : IStudentService
    {
        private readonly DataSource _dataSource;

        public StudentService(DataSource dataSource)
        {
            if (dataSource == null)
                throw new ArgumentNullException(nameof(dataSource));

            _dataSource = dataSource;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await Task.FromResult(_dataSource.Students);
        }

        public async Task<Student> GetStudent(int studentId)
        {
            return await Task.FromResult(_dataSource.Students.FirstOrDefault(x => x.Id == studentId));
        }

        public async Task<int> GetNewModelId()
        {
            return await Task.FromResult(_dataSource.Students.Max(x => x.Id) + 1);
        }

        public async Task CreateNewStudent(Student student)
        {
            await Task.Run(() => _dataSource.Students.Add(student));
        }

        public async Task RemoveStudent(int studentId)
        {
            await Task.Run(() => _dataSource.Students.RemoveAll(x => x.Id == studentId));
        }

        public async Task AddStudent(Student student)
        {
            await Task.Run(() => _dataSource.Students.Add(student));
        }
    }
}
