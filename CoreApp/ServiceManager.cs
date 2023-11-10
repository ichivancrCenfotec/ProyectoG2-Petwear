using DataAccess;
using DTOs;
using System;


namespace CoreApp
{
    public class ServiceManager
    {
        public void Create(Service service)
        {
            var uc = new ServiceCrudFactory();
            uc.Create(service);
        }

        public List<Service> RetrieveAll()
        {
            var uc = new ServiceCrudFactory();
            return uc.RetrieveAll<Service>();

        }

        public Service RetrieveById(Service service)
        {
            var uc = new ServiceCrudFactory();
          return  uc.RetrieveById<Service>(service.Id);
        }
     

        public void Update(Service service)
        {
            var uc = new ServiceManager();
            uc.Update(service);
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



