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
            sqlOperation.AddIntParam("P_ID", petData.IdPet);
            sqlOperation.AddFloatParam("P_TEMPERATURE", petData.Temperature);
            sqlOperation.AddIntParam("P_HUMIDITY", petData.Humidity);
            sqlOperation.AddIntParam("P_ULTRAVIOLET", petData.UltraViolet);

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
            throw new NotImplementedException();
        }

        public override T RetrieveByEmail<T>(string email)
        {
            throw new NotImplementedException();
        }

        public override T RetrieveById<T>(int id)
        {
            throw new NotImplementedException();
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