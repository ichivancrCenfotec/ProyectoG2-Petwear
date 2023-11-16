using DataAccess;
using DTOs;
using System;


namespace CoreApp
{
    public class ServiceManager
    {
        public void Create(Service service)
        {
            if (service.Cost < 0)
            {
                throw new Exception("Please type a correct cost");
            }
            if (service.Description.Equals(""))
            {
                throw new Exception("There cannot be blank fields");
            }
            else
            {
                var sc = new ServiceCrudFactory();
                sc.Create(service);
            }
        }

        public List<Service> RetrieveAll()
        {
            var sc = new ServiceCrudFactory();
            return sc.RetrieveAll<Service>();
        }

        public Service RetrieveById(Service service)
        {
            var sc = new ServiceCrudFactory();
          return  sc.RetrieveById<Service>(service.Id);
        }
     

        public void Update(Service service)
        {
            var sc = new ServiceManager();
            sc.Update(service);
        }

        public void Delete(Service service)
        {
            var sc = new ServiceCrudFactory();
            sc.Delete(service);
        }
    }

}



