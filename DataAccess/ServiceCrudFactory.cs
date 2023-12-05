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
    public class ServiceCrudFactory : CrudFactory
    {

        public ServiceCrudFactory()
        {
            _dao = SqlDao.GetInstance();
        }


        public override void Create(BaseDTO baseDTO)
        {
            var service = baseDTO as Service;

            var sqlOperation = new SqlOperation { ProcedureName = "CRE_SERVICE_PR" };
            sqlOperation.AddFloatParam("P_COST", service.Cost);
            sqlOperation.AddVarcharParam("P_SERVICENAME", service.ServiceName);
            sqlOperation.AddVarcharParam("P_DESCRIPTION", service.Description);
            sqlOperation.AddIntParam("P_AVAILABILITY", service.Availability);

            _dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO baseDTO)
        {
            var service = baseDTO as Service;

            var sqlOperation = new SqlOperation { ProcedureName = "DELETE_SERVICE_PR" };
            sqlOperation.AddIntParam("P_ID", service.Id);
        }

        public override T Retrieve<T>()
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstService = new List<T>();

            var sqlOperation = new SqlOperation { ProcedureName = "RET_ALL_SERVICE_PR" };

            //Devuelve la lista de diccionarios
            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);
            if (lstResults.Count > 0)
            {
                foreach (var row in lstResults)
                {
                  
                    var serviceDTO = BuildService<T>(row);

                    lstService.Add((T)Convert.ChangeType(serviceDTO, typeof(T)));
                }
            }
            return lstService;

        }
        private T BuildService<T>(Dictionary<string, object> row)
        {
            //Construir el objeto
            var service = new Service()
            {
                IdService = (int)row["ID_SERVICE"],
                Cost = Convert.ToSingle(row["COST"]),
                ServiceName = (string)row["SERVICE_NAME"],
                Description = (string)row["DESCRIPTION"],
                Availability = (int)row["AVAILABILITY"]
            };
            return (T)Convert.ChangeType(service, typeof(T));

        }


        public override T RetrieveById<T>(int id)

        {
            throw new NotImplementedException();
        }

        public override void Update(BaseDTO baseDTO)
        {
            var service = baseDTO as Service;

            var sqlOperation = new SqlOperation { ProcedureName = "UPDATE_SERVICE_PR" };
            sqlOperation.AddIntParam("P_IdService", service.Id);
            sqlOperation.AddFloatParam("P_Cost", service.Cost);
            sqlOperation.AddVarcharParam("P_ServiceName", service.ServiceName);
            sqlOperation.AddVarcharParam("P_Description", service.Description);
            sqlOperation.AddIntParam("P_Availability", service.Availability);

            _dao.ExecuteProcedure(sqlOperation);
        }

        public override T RetrieveByEmail<T>(string email)
        {
            throw new NotImplementedException();
        }

        public override void ResetPassword(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        public override void NewPassword(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        public override void VerifyStatus(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        public override void AddService(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAllById<T>(int id)
        {
            var lstService = new List<T>();

            var sqlOperation = new SqlOperation { ProcedureName = "RET_ALL_SERVICE_BY_ID_PR" };
            sqlOperation.AddIntParam("P_IDPACKAGE", id);

            //Devuelve la lista de diccionarios
            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);
            if (lstResults.Count > 0)
            {
                foreach (var row in lstResults)
                {

                    var serviceDTO = BuildService<T>(row);

                    lstService.Add((T)Convert.ChangeType(serviceDTO, typeof(T)));
                }
            }
            return lstService;
        }
    }


}

