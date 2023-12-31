﻿using DataAccess.CRUD;
using DataAccess.DAOs;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookingCrudFactory : CrudFactory
    {

        public BookingCrudFactory()
        {
            _dao = SqlDao.GetInstance();
        }

        public override void Create(BaseDTO baseDTO)
        {
            var booking = baseDTO as Booking;

            var packageCrudFactory = new PackageCrudFactory();

            var package = packageCrudFactory.RetrieveById<Package>(booking.IdPackage);

            booking.TotalPrice = package.Cost;

            var sqlOperation = new SqlOperation { ProcedureName = "CRE_BOOKING_PR" };
            sqlOperation.AddDateTimeParam("P_checkInDate", booking.CheckInDate);
            sqlOperation.AddDateTimeParam("P_checkOutDate", booking.CheckOutDate);
            sqlOperation.AddVarcharParam("P_considerations", booking.Considerations);
            sqlOperation.AddVarcharParam("P_status", booking.Status);
            sqlOperation.AddIntParam("P_id", booking.IdUser);
            sqlOperation.AddIntParam("P_idPet", booking.IdPet);
            sqlOperation.AddIntParam("P_idPackage", booking.IdPackage);
            sqlOperation.AddFloatParam("P_totalPrice", booking.TotalPrice);


            _dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO baseDTO)
        {
            var booking = baseDTO as Booking;

            var sqlOperation = new SqlOperation {ProcedureName= "DELETE_BOOKING" };
            sqlOperation.AddIntParam("P_IDBOOKING", booking.idBooking);

            _dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>()
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstBooking = new List<T>();

            var sqlOperation = new SqlOperation { ProcedureName = "RET_ALL_BOOKING" };

            //Devuelve la lista de diccionarios
            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);
            if (lstResults.Count > 0)
            {
                foreach (var row in lstResults)
                {
                    var bookingDTO = new Booking()
                    {
                        Id = (int)row["ID_BOOKING"],
                        CheckInDate = (DateTime)row["CHECK_IN"],
                        CheckOutDate = (DateTime)row["CHECK_OUT"],
                        Considerations = (string)row["CONSIDERATIONS"],
                        Status = (string)row["STATUS"],
                        IdUser = (int)row["ID"],
                        IdPet = (int)row["IDPET"],
                        IdPackage = (int)row["ID_PACKAGE"],
                        TotalPrice = Convert.ToSingle(row["TOTALPRICE"])
                    };
                    lstBooking.Add((T)Convert.ChangeType(bookingDTO, typeof(T)));
                }
            }
            return lstBooking;
        }
        private T BuildBooking<T>(Dictionary<string, object> row)
        {
            //Construir el objeto
            var booking = new Booking()
            {
                Id = (int)row["idBooking"],
                CheckInDate = (DateTime)row["checkInDate"],
                CheckOutDate = (DateTime)row["checkOutDate"],
                Considerations = (string)row["considerations"],
                Status = (string)row["status"],
                IdUser = (int)row["idUser"],
                IdPet = (int)row["idPet"],
                IdPackage = (int)row["idPackage"],
                TotalPrice = Convert.ToSingle(row["totalPrice"])

            };
            return (T)Convert.ChangeType(booking, typeof(T));

        }

        public override T RetrieveById<T>(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "RET_ID_BOOKING_PR" };

            sqlOperation.AddIntParam("ID", id);

            var lstResults = _dao.ExecuteQueryProcedure(sqlOperation);
            if (lstResults.Count > 0)
            {
                var row = lstResults[0];

                //Construir el objeto
                var bookingDTO = BuildBooking<T>(row);
                return bookingDTO;

            }
            return default(T);
        }

        public override void Update(BaseDTO baseDTO)
        {
            var booking = baseDTO as Booking;

            var packageCrudFactory = new PackageCrudFactory();

            var package = packageCrudFactory.RetrieveById<Package>(booking.IdPackage);

            booking.TotalPrice = package.Cost;

            var sqlOperation = new SqlOperation { ProcedureName = "UPDATE_BOOKING" };
            sqlOperation.AddIntParam("P_IDBOOKING", booking.idBooking);
            sqlOperation.AddDateTimeParam("P_CHECK_IN", booking.CheckInDate);
            sqlOperation.AddDateTimeParam("P_CHECK_OUT", booking.CheckOutDate);
            sqlOperation.AddVarcharParam("P_CONSIDERATIONS", booking.Considerations);
            sqlOperation.AddVarcharParam("P_STATUS", booking.Status);
            sqlOperation.AddIntParam("P_ID", booking.IdUser);
            sqlOperation.AddIntParam("P_IDPET", booking.IdPet);
            sqlOperation.AddIntParam("P_IDPACKAGE", booking.IdPackage);
            sqlOperation.AddFloatParam("P_TOTALPRICE", booking.TotalPrice);


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
            throw new NotImplementedException();
        }

        public override void UpdateRole(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }
    }
}
