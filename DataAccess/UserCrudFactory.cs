using DataAccess.CRUD;
using DataAccess.DAOs;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserCrudFactory : CrudFactory
    {

      public UserCrudFactory()
        {
            _dao = SqlDao.GetInstance();
        }


        public override void Create(BaseDTO baseDTO)
        {
            //Conversion del baseDTO al user
            var user = baseDTO as User;

            //vamos a definir el SqlOperation para esta operación de creación
            var SqlOperation = new SqlOperation { ProcedureName = "CRE_USER_PR" };
            SqlOperation.AddVarcharParam("P_NAME", user.Name);
            SqlOperation.AddVarcharParam("P_LASTNAME", user.LastName);
            SqlOperation.AddVarcharParam("P_PASSWORD", user.Password);
            SqlOperation.AddVarcharParam("P_EMAIL", user.Email);
            SqlOperation.AddVarcharParam("P_ADDRESS", user.Address);
            SqlOperation.AddVarcharParam("P_ROLE", user.Role);
            SqlOperation.AddIntParam("P_PHONENUMBER", user.PhoneNumber);

            //Invocamos al SQLDao y le indicamos que ejecute el SP
            _dao.ExecuteProcedure(SqlOperation);

        }

        public override void Delete(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        public override T Retrieve<T>()
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {

            var lstUsers = new List<T>();

            var sqlOperation = new SqlOperation { ProcedureName = "RET_ALL_USERS_PR" };

            //Devuelve la lista de diccionarios
            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                foreach (var row in lstResults)
                {
                    var userDTO = BuildUser<T>(row);
                    lstUsers.Add(userDTO);
                }
            }

            throw new NotImplementedException();

            if (lstResults.Count > 0)
            {
                foreach (var row in lstResults)
                {
                    var userDTO = BuildUser<T>(row);
                    lstUsers.Add(userDTO);
                }
            }

        }

        private T BuildUser<T>(Dictionary<string, object> row)
        {
            throw new NotImplementedException();

        }

    

        public T RetrieveByEmail<T>(int id)
        {
            //extraemos el primer valor de la lista
            var row = lstResults[0]; //solo hay 1 resultado

            //contruir el objeto
            var userDTO = BuildUser<T>(row);
            return userDTO;

        }
        return defaultpublic override T RetrieveById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        (T);

    }


        public T RetrieveByEmail<T>(int Id) => throw new NotImplementedException();


        public override void Update(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }


    
}
