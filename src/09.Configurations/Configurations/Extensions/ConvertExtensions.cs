﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Configurations.DBModels;
using Configurations.Models;

namespace Configurations.Extensions
{
    public static class ConvertExtensions
    {
        public static StudentVM ConvertStudentToVM(this StudentDBModel student)
        {
            if (student == null)
                return null;

            return new StudentVM
            {
                Id = student.Id,
                BirthDate = student.BirthDate,
                City = student.City,
                FirstName = student.FirstName,
                LastName = student.LastName,
                MiddleName = student.MiddleName,
                Gender = student.Gender,
                TabelNumber = student.TabelNumber
            };
        }

        public static StudentDBModel ConvertStudentToDBModel(this StudentVM student)
        {
            if (student == null)
                return null;

            return new StudentDBModel
            {
                Id = student.Id,
                BirthDate = student.BirthDate,
                City = student.City,
                FirstName = student.FirstName,
                LastName = student.LastName,
                MiddleName = student.MiddleName,
                Gender = student.Gender,
                TabelNumber = student.TabelNumber
            };
        }
    }
}
