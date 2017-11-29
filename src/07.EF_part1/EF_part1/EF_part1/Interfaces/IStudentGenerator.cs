using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_part1.Models;

namespace EF_part1.Interfaces
{
    public interface IStudentGenerator
    {
        Task<StudentsModelVM> GetStudentsModel();
        Task<StudentVM> GetStudent(int studentId);
        Task<StudentVM> GetNewStudentModel();
    }
}
