﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_part2.Models
{
    public class StudentsModelVM
    {
        public IEnumerable<StudentVM> Students { get; set; }
    }
}
