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
        public void Create(PetData pd)
        {
            var pdf = new IDEACrudFactory();
            pdf.Create(pd);
        }
        public object? RetrieveAll()
        {
            var uc = new IDEACrudFactory();
            return uc.RetrieveAll<PetData>();
        }
        public object? RetrieveById(PetData pet) 
        {
            var uc = new IDEACrudFactory();
            return uc.RetrieveAll<PetData>();
        }
    }
}