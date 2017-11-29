using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DAO
{
    public abstract class BaseDAO
    {
        //private readonly Iamb

        protected StudentDbContext _context => null;

        protected BaseDAO()
        {
            _context
        }
    }
}
