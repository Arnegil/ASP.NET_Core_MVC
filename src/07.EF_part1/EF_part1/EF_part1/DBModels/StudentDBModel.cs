using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_part1.DBModels
{

    public class StudentDBModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public int TabelNumber { get; set; }
    }
}