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
            //Conversion del baseDTO al user
            var service = baseDTO as Service;

            //vamos a definir el SqlOperation para esta operación de creación
            var SqlOperation = new SqlOperation { ProcedureName = "CRE_SERVICE_PR" };
            SqlOperation.AddVarcharParam("P_DESCRIPTION", service.Description);
            SqlOperation.AddFloatParam("P_COST", service.Cost);

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

            var lstServices = new List<T>();

            var sqlOperation = new SqlOperation { ProcedureName = "RET_ALL_SERVICES_PR" };

            //Devuelve la lista de diccionarios
            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                foreach (var row in lstResults)
                {
                    var serviceDTO = BuildService<T>(row);
                    lstServices.Add(serviceDTO);
                }
            }

            return lstServices;
        }

        public override T RetrieveById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }
    }

    public override T RetrieveById<T>(int id)
    {
        var sqlOperation = new SqlOperation { ProcedureName = "RET_SERVICE_BY_ID_PR" };

        sqlOperation.AddIntParam("P_ID", id); //agarra el id con el parametro definido en el PR de BD

        //Devuelve la lista de diccionarios
        var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);

        if (lstResults.Count > 0)
        {
            //extraemos el primer valor de la lista
            var row = lstResults[0]; //solo hay 1 resultado

            //contruir el objeto
            var serviceDTO = BuildService<T>(row);
            return serviceDTO;

        }
        return default(T);

    }

    private T BuildService<T>(Dictionary<string, object> row)
    {
        //Construir el objeto
        var serviceDTO = new Service()
        {
            Id = (int)row["ID"],
            Description = (string)row["DESCRIPTION"],
            Cost = (float)row["COST"]
        };
        return (T)Convert.ChangeType(serviceDTO, typeof(T));

    }


    public T RetrieveByEmail<T>(int id)
    {
        throw new NotImplementedException();
    }


    public override void Update(BaseDTO baseDTO)
    {
        throw new NotImplementedException();
    }

}
}
