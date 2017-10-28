using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_part1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public int TabelNumber { get; set; }

        public string FullName
        {
            get
            {
                if (string.IsNullOrEmpty(LastName) ||
                    string.IsNullOrEmpty(FirstName) ||
                    string.IsNullOrEmpty(MiddleName))
                    return null;

                return $"{LastName} {FirstName[0]}. {MiddleName[0]}.";
            }
        }
}
}
