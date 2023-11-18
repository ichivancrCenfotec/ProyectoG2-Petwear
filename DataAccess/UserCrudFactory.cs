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
            //cONVERSION DEL baseDTO al user
            var user = baseDTO as User;

            //Vamos a definir el SqlOperation para esta operacion de creacion
            var sqlOperation = new SqlOperation { ProcedureName = "CRE_USER_PW" };
            sqlOperation.AddVarcharParam("P_NAME", user.Name);
            sqlOperation.AddVarcharParam("P_LAST_NAME", user.LastName);
            sqlOperation.AddVarcharParam("P_PASSWORD", user.Password);
            sqlOperation.AddVarcharParam("P_EMAIL", user.Email);
            sqlOperation.AddVarcharParam("P_ADDRESS", user.Address);
            sqlOperation.AddVarcharParam("P_ROLE", user.Role);
            sqlOperation.AddIntParam("P_PHONE_NUMBER", user.PhoneNumber);
            sqlOperation.AddVarcharParam("P_VALIDATIONOTP", "FSDUIFH");
            sqlOperation.AddVarcharParam("P_RESETOTP", "DSAODJHSA");


            //Invocamos

            _dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO baseDTO)
        {
            var user = baseDTO as User;

            var sqlOperation = new SqlOperation { ProcedureName = "DEL_USER_PW" };
            sqlOperation.AddIntParam("P_ID", user.Id);

            _dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>()
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstUsers = new List<T>();

            var sqlOperation = new SqlOperation { ProcedureName = "RET_ALL_USERS_PW" };

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

            return lstUsers;
        }



        public override T RetrieveByEmail<T>(string email)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "RET_BY_EMAIL_PW" };
            sqlOperation.AddVarcharParam("P_EMAIL", email);

            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                //Extraermos el primer valor de la lista
                var row = lstResults[0];

                var userDTO = BuildUser<T>(row);
                return userDTO;
            }
            return default(T);
        }

        public override T RetrieveById<T>(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "RET_BY_ID_PW" };
            sqlOperation.AddIntParam("P_ID", id);

            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                //Extraermos el primer valor de la lista
                var row = lstResults[0];

                var userDTO = BuildUser<T>(row);
                return userDTO;
            }
            return default(T);
        }


        /*
           public override T RetrieveByEmail<T>(string email)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "RET_BY_Email_PW" };
            sqlOperation.AddVarcharParam("P_Email", email);

            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                //Extraermos el primer valor de la lista
                var row = lstResults[0];

                var userDTO = BuildUser<T>(row);
                return userDTO;
            }
            return default(T);
        }
        public override T RetrieveByPassword<T>(string email)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "RET_BY_PASS_PW" };
            sqlOperation.AddVarcharParam("P_Email", email);

            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                //Extraermos el primer valor de la lista
                var row = lstResults[0];

                var userDTO = BuildUser<T>(row);
                return userDTO;
            }
            return default(T);
        }

        public override void OTP(BaseDTO baseDTO)
        {
            //cONVERSION DEL baseDTO al user
            var user = baseDTO as User;

            //Vamos a definir el SqlOperation para esta operacion de creacion
            var sqlOperation = new SqlOperation { ProcedureName = "OTP_USER_PW" };
            sqlOperation.AddVarcharParam("P_PASSWORD", GenerateRandomString(15));
            sqlOperation.AddVarcharParam("P_EMAIL", user.Email);


            //Invocamos

            _dao.ExecuteProcedure(sqlOperation);


            static string GenerateRandomString(int length)
            {
                // Caracteres que se pueden usar en la cadena aleatoria
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789#$%&/";

                // Inicializar el generador de números aleatorios
                Random random = new Random();

                // Crear una cadena aleatoria usando un StringBuilder
                StringBuilder randomString = new StringBuilder(length);
                for (int i = 0; i < length; i++)
                {
                    // Seleccionar un carácter aleatorio de la cadena de caracteres
                    randomString.Append(chars[random.Next(chars.Length)]);
                }

                // Devolver la cadena aleatoria generada
                return randomString.ToString();
            }
        }
         
         
         
         */



        public override void Update(BaseDTO baseDTO)
        {
            //cONVERSION DEL baseDTO al user
            var user = baseDTO as User;

            //Vamos a definir el SqlOperation para esta operacion de creacion
            var sqlOperation = new SqlOperation { ProcedureName = "UPDATE_USER_PW" };
            sqlOperation.AddIntParam("P_ID", user.Id);
            sqlOperation.AddVarcharParam("P_NAME", user.Name);
            sqlOperation.AddVarcharParam("P_LAST_NAME", user.LastName);
            sqlOperation.AddVarcharParam("P_PASSWORD", user.Password);
            sqlOperation.AddVarcharParam("P_EMAIL", user.Email);
            sqlOperation.AddVarcharParam("P_ADDRESS", user.Address);
            sqlOperation.AddVarcharParam("P_ROLE", user.Role);
            sqlOperation.AddIntParam("P_PHONE_NUMBER", user.PhoneNumber);
            sqlOperation.AddVarcharParam("P_VALIDATIONOTP", user.ValidationOTP);
            sqlOperation.AddVarcharParam("P_RESETOTP", user.ResetOTP);
        

            //Invocamos

            _dao.ExecuteProcedure(sqlOperation);
        }

        private T BuildUser<T>(Dictionary<string, object> row)
        {
            var user = new User
            {
                Id = (int)row["ID"],
                Name = (string)row["NAME"],
                LastName = (string)row["LASTNAME"],
                Password = (string)row["PASSWORD"],
                Email = (string)row["EMAIL"],
                Address = (string)row["ADDRESS"],
                Role = (string)row["ROLE"],
                PhoneNumber = (int)row["PHONENUMBER"],
           
            };

            return (T)Convert.ChangeType(user, typeof(T));
        }

    }
}