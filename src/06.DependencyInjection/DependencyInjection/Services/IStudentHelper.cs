using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Services
{
    public interface IStudentHelper
    {
        bool IsCoolTableNumber(int tabelNumber);
    }

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
