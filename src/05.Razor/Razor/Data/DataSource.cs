using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Razor.Models;

namespace Razor.Data
{
    public static class DataSource
    {
        public static readonly List<Student> Students;

        static DataSource()
        {
            Students = new List<Student>
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
                    BirthDate = new DateTime(1994, 04, 23),
                    TabelNumber = 4927512
                }
            };
        }
    }
}
