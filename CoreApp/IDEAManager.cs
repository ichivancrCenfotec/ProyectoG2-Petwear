using DataAccess;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp
{
    public class IDEAManager
    {
        public object? RetrieveAll()
        {
            var uc = new IDEACrudFactory();
            return uc.RetrieveAll<PetData>();
        }
    }
}