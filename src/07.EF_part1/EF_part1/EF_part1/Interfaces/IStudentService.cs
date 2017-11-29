using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_part1.DBModels;

namespace EF_part1.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int studentId);
        Task AddStudent(Student student);
        Task RemoveStudent(int studentId);
        Task UpdateStudent(Student student);
    }
}
