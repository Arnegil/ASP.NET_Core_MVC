using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Configurations.Models;

namespace Configurations.Interfaces
{
    public interface IStudentGenerator
    {
        Task<StudentsModelVM> GetStudentsModel();
        Task<StudentVM> GetStudent(int studentId);
        Task<StudentVM> GetNewStudentModel();
    }
}
