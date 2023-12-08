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

        public override void AddService(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        public override void Create(BaseDTO baseDTO)
        {
            var pet = baseDTO as Pet;

            var sqlOperation = new SqlOperation { ProcedureName = "CRE_PET" };
            sqlOperation.AddVarcharParam("P_NAME_PET", pet.NamePet);
            sqlOperation.AddIntParam("P_AGE", pet.Age);
            sqlOperation.AddVarcharParam("P_BREED", pet.Breed);
            sqlOperation.AddFloatParam("P_WEIGHT", pet.Weight);
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
            var sqlOperation = new SqlOperation { ProcedureName = "RET_PET_BY_ID" };
            sqlOperation.AddIntParam("P_IDPET", id);

            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                var row = lstResults[0];

                //Construir el objeto
                var petDTO = BuildPet<T>(row);
                return petDTO;

            }
            return default(T);
        }

        public override void Update(BaseDTO baseDTO)
        {
           var pet = baseDTO as Pet;

            var sqlOperation = new SqlOperation { ProcedureName = "UPDATE_PET" };
            sqlOperation.AddIntParam("P_ID_PET", pet.idPet);
            sqlOperation.AddVarcharParam("P_NAME_PET", pet.NamePet);
            sqlOperation.AddIntParam("P_AGE", pet.Age);
            sqlOperation.AddVarcharParam("P_BREED", pet.Breed);
            sqlOperation.AddFloatParam("P_WEIGHT", pet.Weight);
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

                idPet = (int)row["IDPET"],
                NamePet = (string)row["NAMEPET"],
                Age = (int)row["AGE"],
                Breed = (string)row["BREED"],
                Weight = (float)(double)row["WEIGHT"],
                Description = (string)row["DESCRIPTION"],
                LevelAggressiveness = (int)row["LEVELAGGRESSIVENESS"],
                FotoUno = (string)row["PHOTO1"],
                FotoDos = (string)row["PHOTO2"]
            };

            return (T)Convert.ChangeType(pet, typeof(T));
        }

        public override List<T> RetrieveAllById<T>(int id)
        {
            var lstService = new List<T>();
            System.Console.WriteLine("parametro en manager= " + id);
            var sqlOperation = new SqlOperation { ProcedureName = "RET_ALL_PETS_BY_USER" };
            sqlOperation.AddIntParam("ID", id);//Parametro que se envia

            // Devuelve la lista de diccionarios
            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);

            if (lstResults.Count > 0)
            {
                foreach (var row in lstResults)
                {

                    var petDTO = BuildPet<T>(row);
                    lstService.Add(petDTO);

                }
            }
            return lstService;
        }
    }
}

