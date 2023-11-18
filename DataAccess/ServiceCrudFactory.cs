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
            sqlOperation.AddIntParam("P_IdPackage", service.IdPackage);
            sqlOperation.AddFloatParam("P_Cost", service.Cost);
            sqlOperation.AddVarcharParam("P_ServiceName", service.ServiceName);
            sqlOperation.AddVarcharParam("P_Description", service.Description);
            sqlOperation.AddBoolParam("P_Availability", service.Availability);

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
            var lstBooking = new List<T>();

            var sqlOperation = new SqlOperation { ProcedureName = "RET_ALL_SERVICE_PR" };

            //Devuelve la lista de diccionarios
            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);
            if (lstResults.Count > 0)
            {
                foreach (var row in lstResults)
                {
                    var serviceDTO = new Service()
                    {
                        Id = (int)row["idService"],
                        IdPackage = (int)row["idPackage"],
                        Cost = Convert.ToSingle(row["cost"]),
                        ServiceName = (string)row["serviceName"],
                        Description = (string)row["description"],
                        Availability = (bool)row["availability"]
                    };
                    lstBooking.Add((T)Convert.ChangeType(serviceDTO, typeof(T)));
                }
            }
            return lstBooking;

        }
        private T BuildService<T>(Dictionary<string, object> row)
        {
            //Construir el objeto
            var service = new Service()
            {
                Id = (int)row["idService"],
                IdPackage = (int)row["idPackage"],
                Cost = Convert.ToSingle(row["cost"]),
                ServiceName = (string)row["serviceName"],
                Description = (string)row["description"],
                Availability = (bool)row["availability"]
            };
            return (T)Convert.ChangeType(service, typeof(T));

        }


        public override T RetrieveById<T>(int id)

        {
            var sqlOperation = new SqlOperation { ProcedureName = "RET_ID_SERVICE_PR" };

            sqlOperation.AddIntParam("ID", id);

            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);
            if (lstResults.Count > 0)
            {
                var row = lstResults[0];

                //Construir el objeto
                var serviceDTO = BuildService<T>(row);
                return serviceDTO;

            }
            return default(T);
        }

        public override void Update(BaseDTO baseDTO)
        {
            var service = baseDTO as Service;

            var sqlOperation = new SqlOperation { ProcedureName = "UPDATE_SERVICE_PR" };
            sqlOperation.AddIntParam("P_IdService", service.Id);
            sqlOperation.AddIntParam("P_IdPackage", service.IdPackage);
            sqlOperation.AddFloatParam("P_Cost", service.Cost);
            sqlOperation.AddVarcharParam("P_ServiceName", service.ServiceName);
            sqlOperation.AddVarcharParam("P_Description", service.Description);
            sqlOperation.AddBoolParam("P_Availability", service.Availability);

            _dao.ExecuteProcedure(sqlOperation);
        }

        public override T RetrieveByEmail<T>(string email)
        {
            throw new NotImplementedException();
        }
    }


}

