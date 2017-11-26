using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjection.Models;

namespace DependencyInjection.Services
{
    public class DataSource
    {
        private static readonly List<Student> _students;
        public List<Student> Students => _students;

        static DataSource()
        {
            _students = new List<Student>
            {
                new Student
                {
                    Id = 0,
                    FirstName = "Петр",
                    MiddleName = "Петрович",
                    LastName = "Петров",
                    City = "Екатеринбург",
                    BirthDate = new DateTime(1995, 04, 23),
                    TabelNumber = 4927592
                },
                new Student
                {
                    Id = 1,
                    FirstName = "Иван",
                    MiddleName = "Иванович",
                    LastName = "Иванов",
                    City = "Москва",
                    BirthDate = new DateTime(1994, 04, 27),
                    TabelNumber = 4927512
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Сидоров",
                    MiddleName = "Петрович",
                    LastName = "Иванов",
                    City = "Москва",
                    BirthDate = new DateTime(1994, 02, 13),
                    TabelNumber = 777
                }
            };
        }
    }
}
