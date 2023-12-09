using DataAccess;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp
{
    public class PetManager
    {

        public void Create(Pet pet)
        {
            var pc = new PetCrudFactory();
            pc.Create(pet);
        }

        public void Update(Pet pet)
        {
            var pc = new PetCrudFactory();
            pc.Update(pet);
        }


        public void Delete(Pet pet)
        {
            var pc = new PetCrudFactory();
            pc.Delete(pet);
        }


        public object? RetrieveAll()
        {
            var pc = new PetCrudFactory();
            return pc.RetrieveAll<Pet>();
        }

        public object? RetrieveById(Pet pet)
        {
            var pc = new PetCrudFactory();
            return pc.RetrieveById<User>(pet.Id);
        }

        public void AddPet(Pet pet)
        {
            var uc = new PetCrudFactory();
            uc.AddService(pet);
        }
    }
}
