using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Configurations.DBModels;

namespace Configurations.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDBModel>> GetStudents();
        Task<StudentDBModel> GetStudent(int studentId);
        Task<int> AddStudent(StudentDBModel student);
        Task RemoveStudent(int studentId);
        Task<int> UpdateStudent(StudentDBModel student);
    }
}
