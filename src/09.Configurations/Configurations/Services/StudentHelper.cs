using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Configurations.Interfaces;

namespace Configurations.Services
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
