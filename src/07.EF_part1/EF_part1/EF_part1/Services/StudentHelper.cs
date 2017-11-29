﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_part1.Interfaces;

namespace EF_part1.Services
{
    public class StudentHelper : IStudentHelper
    {
        public bool IsCoolTableNumber(int tabelNumber)
        {
            if (tabelNumber.ToString().ToCharArray().Distinct().Count() == 1)
                return true;

            return false;
        }
    }
}
