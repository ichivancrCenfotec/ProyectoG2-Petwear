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
    public class IDEACrudFactory : CrudFactory
    {
        public IDEACrudFactory()

        {
            _dao = SqlDao.GetInstance();
        }

        public override void Create(BaseDTO baseDTO)
        {
            //cONVERSION DEL baseDTO al petData
            var petData = baseDTO as PetData;

            //Vamos a definir el SqlOperation para esta operacion de creacion
            var sqlOperation = new SqlOperation { ProcedureName = "CRE_PETDATA_PW" };
            sqlOperation.AddIntParam("P_IDPET", petData.IdPet);
            sqlOperation.AddFloatParam("P_TEMPERATURE", petData.Temperature);
            sqlOperation.AddIntParam("P_HUMIDITY", petData.Humidity);
            sqlOperation.AddFloatParam("P_ULTRAVIOLET", petData.UltraViolet);

            //Invocamos

            _dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        public override void NewPassword(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        public override void ResetPassword(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        public override T Retrieve<T>()
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstPetData = new List<T>();

            var sqlOperation = new SqlOperation { ProcedureName = "RET_ALL_PETDATA_PW" };

            //Devuelve la lista de diccionarios

            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);


            if (lstResults.Count > 0)
            {
                foreach (var row in lstResults)
                {

                    var petdata = BuildPetData<T>(row);

                    lstPetData.Add(petdata);

                }

            }

            return lstPetData;
        }
        private T BuildPetData<T>(Dictionary<string, object> row)
        {
            var pet = new PetData
            {
                Id = (int)row["ID"],
                IdPet = (int)row["IDPET"],
                Temperature = (float)Convert.ToSingle(row["TEMPERATURE"]),
                Humidity = (int)row["HUMIDITY"],
                UltraViolet = (float)Convert.ToSingle(row["ULTRAVIOLET"]),
                Created = (DateTime)row["CREATED"]
            };

            return (T)Convert.ChangeType(pet, typeof(T));
        }

        public override T RetrieveByEmail<T>(string email)
        {
            throw new NotImplementedException();
        }

        public override T RetrieveById<T>(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "RET_BY_ID_PETDATA" };
            sqlOperation.AddIntParam("P_ID", id);

            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                //Extraermos el primer valor de la lista
                var row = lstResults[0];

                var petData = BuildPetData<T>(row);
                return petData;
            }
            return default(T);
        }
        public override void Update(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        public override void VerifyStatus(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }
    }
}