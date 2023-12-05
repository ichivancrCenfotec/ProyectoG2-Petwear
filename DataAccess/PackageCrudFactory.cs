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
    public class PackageCrudFactory : CrudFactory
    {

        public PackageCrudFactory()
        {
            _dao = SqlDao.GetInstance();
        }

        public override void AddService(BaseDTO baseDTO)
        {
            var package_service = baseDTO as Package_Service;

            var sqlOperation = new SqlOperation { ProcedureName = "ADD_SERVICE" };

            sqlOperation.AddIntParam("P_IDPACKAGE", package_service.IdPackage);
            sqlOperation.AddIntParam("P_IDSERVICE", package_service.IdService);



            //Invocamos
            _dao.ExecuteProcedure(sqlOperation);
        }

        public override void Create(BaseDTO baseDTO)
        {
            var package = baseDTO as Package;
            var sqlOperation = new SqlOperation { ProcedureName = "CRE_PACKAGE" };

            sqlOperation.AddVarcharParam("P_PACKAGENAME", package.NamePackage);
            sqlOperation.AddFloatParam("P_COST", package.Cost);
            sqlOperation.AddVarcharParam("P_DESCRIPTION", package.Description);



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
           var lstPackages = new List<T>();
            var sqlOperation = new SqlOperation { ProcedureName = "RET_ALL_PACKAGES" };

            var lstResult = _dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResult.Count > 0)
            {
              
                foreach (var row in lstResult)
                {
                    var userDTO = BuildPackage<T>(row);
                    lstPackages.Add(userDTO);
                }

            }

            return lstPackages;
      
        }

        public override List<T> RetrieveAllById<T>(int id)
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

        private T BuildPackage<T>(Dictionary<string, object> row)
        {
            var package = new Package
            {
                IdPackage = (int)row["ID_PACKAGE"],
                NamePackage = (string)row["NAME_PACKAGE"],
                Cost = (float)(double)row["COST"],
                Description = (string)row["DESCRIPTION"],
             
            };

            return (T)Convert.ChangeType(package, typeof(T));
        }
    }
}
