using DataAccess;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp
{
    public class UserManager
    {

        public void Create(User user)
        {
            var uc = new UserCrudFactory();
            uc.Create(user);
        }

        public void Update(User user)
        {
            var uc = new UserCrudFactory();
            uc.Update(user);
        }


        public void Delete(User user)
        {
            var uc = new UserCrudFactory();
            uc.Delete(user);
        }


        public object? RetrieveAll()
        {
            var uc = new UserCrudFactory();
            return uc.RetrieveAll<User>();
        }

        public object? RetrieveById(User user)
        {
            var uc = new UserCrudFactory();
            return uc.RetrieveById<User>(user.Id);
        }
    }
}
