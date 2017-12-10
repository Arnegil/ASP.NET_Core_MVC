using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_part2.Models;

namespace EF_part2.Interfaces
{
    public interface IStudentGenerator
    {
        Task<StudentsModelVM> GetStudentsModel();
        Task<StudentVM> GetStudent(int studentId);
        Task<StudentVM> GetNewStudentModel();
    }
}
