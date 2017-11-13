using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Core_MVC.Validation.Attributes;

namespace MVC_part2.Models
{
    public class Student
    {
        [IdValidation]
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(1)]
        public string LastName { get; set; }
        [Required]
        [MinLength(1)]
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
