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
    public class PetCrudFactory : CrudFactory
    {

        public PetCrudFactory()
        {
            _dao = SqlDao.GetInstance();
        }


        public override void Create(BaseDTO baseDTO)
        {
            var pet = baseDTO as Pet;

            var sqlOperation = new SqlOperation { ProcedureName = "CRE_PET" };
            sqlOperation.AddVarcharParam("P_NAME_PET", pet.NamePet);
            sqlOperation.AddIntParam("P_AGE", pet.Age);
            sqlOperation.AddVarcharParam("P_BREED", pet.Breed);
            sqlOperation.AddIntParam("P_WEIGHT", pet.Weight);
            sqlOperation.AddVarcharParam("P_DESCRIPTION", pet.Description);
            sqlOperation.AddIntParam("P_LEVEL_AGGRESSIVENESS", pet.LevelAggressiveness);
            sqlOperation.AddVarcharParam("P_FOTO_UNO", pet.FotoUno);
            sqlOperation.AddVarcharParam("P_FOTO_DOS", pet.FotoDos);


             //Invocamos
            _dao.ExecuteProcedure(sqlOperation);

        }

        public override void Delete(BaseDTO baseDTO)
        {
               var pet = baseDTO as Pet;
            var sqlOperation = new SqlOperation { ProcedureName = "DEL_PET" };
            sqlOperation.AddIntParam("P_ID_PET", pet.idPet);
            _dao.ExecuteProcedure(sqlOperation);
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
           var pet = baseDTO as Pet;

            var sqlOperation = new SqlOperation { ProcedureName = "UPDATE_PET" };
            sqlOperation.AddIntParam("P_ID_PET", pet.idPet);
            sqlOperation.AddVarcharParam("P_NAME_PET", pet.NamePet);
            sqlOperation.AddIntParam("P_AGE", pet.Age);
            sqlOperation.AddVarcharParam("P_BREED", pet.Breed);
            sqlOperation.AddIntParam("P_WEIGHT", pet.Weight);
            sqlOperation.AddVarcharParam("P_DESCRIPTION", pet.Description);
            sqlOperation.AddIntParam("P_LEVEL_AGGRESSIVENESS", pet.LevelAggressiveness);
            sqlOperation.AddVarcharParam("P_FOTO_UNO", pet.FotoUno);
            sqlOperation.AddVarcharParam("P_FOTO_DOS", pet.FotoDos);

            _dao.ExecuteProcedure(sqlOperation);
        }

        public override void VerifyStatus(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        private T BuildPet<T>(Dictionary<string, object> row)
        {
            var pet = new Pet
            {

            }

            return pet as T;
        }
    }
}

