using DataAccess;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoreApp
{
    public class PackageManager
    {

        public void Create(Package package)
        {
            var uc = new PackageCrudFactory();
            uc.Create(package);
        }

        public Package? RetrieveById(Package package)
        {
            var uc = new PackageCrudFactory();
            return uc.RetrieveById<Package>(package.Id);
        }


        public List<Package> RetrieveAll()
        {
            var uc = new PackageCrudFactory();
            return uc.RetrieveAll<Package>();
        }

        public void Update(Package package)
        {
            var uc = new PackageCrudFactory();
            uc.Update(package);
        }

        public void Delete(Package package)
        {
               var uc = new PackageCrudFactory();
                var lstPackage = uc.RetrieveAll<Package>();

            foreach (var item in lstPackage)
            {
                if (item.Id.Equals(package.Id)) 
                {
                    uc.Delete(item);
                }
            }
        }



    }

   
}
