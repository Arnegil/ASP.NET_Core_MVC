﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Razor.Models
{

    public class Student
    {
        [Display(Name = "Идентификатор")]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        [Required]
        [MinLength(1)]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required]
        [MinLength(1)]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        [Required]
        [MinLength(1)]
        public string MiddleName { get; set; }

        [Display(Name = "Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Город")]
        [Required]
        public string City { get; set; }

        [Display(Name = "Номер студенческого")]
        [Required]
        public int TabelNumber { get; set; }

        [Display(Name = "ФИО")]
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
