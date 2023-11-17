using DataAccess.DAOs;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public abstract class CrudFactory
    {
        //Aseguramos dentro del contrato que el unico responsable de ir a la BD
        //sea el SqlDAO.
        protected SqlDao _dao;

        //Contrato de los CRUDs
        //Obliga a definir metodos de CREATE, UPDATE, DELETE Y RETRIEVE
        //Para todos los CRUDS.
        public abstract void Create(BaseDTO baseDTO);
        public abstract T Retrieve<T>();
        public abstract T RetrieveById<T>(int id);
        public abstract List<T> RetrieveAll<T>();
        public abstract void Update(BaseDTO baseDTO);
        public abstract void Delete(BaseDTO baseDTO);

        /*
                public abstract void OTP(BaseDTO baseDTO);

        public abstract T RetrieveByEmail<T>(string email);

        public abstract T RetrieveByPassword<T>(string password);
    
         
         */
    }

    }
