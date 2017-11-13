using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_part2.Models;

namespace MVC_part2.Data
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
                    BirthDate = new DateTime(1990, 04, 23),
                    TabelNumber = 4927592
                }
            };
        }
    }
}
