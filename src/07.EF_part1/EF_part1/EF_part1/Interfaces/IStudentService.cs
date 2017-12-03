using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_part1.DBModels;

namespace EF_part1.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDBModel>> GetStudents();
        Task<StudentDBModel> GetStudent(int studentId);
        Task<int> AddStudent(StudentDBModel student);
        Task RemoveStudent(int studentId);
        Task UpdateStudent(StudentDBModel student);
    }
}
