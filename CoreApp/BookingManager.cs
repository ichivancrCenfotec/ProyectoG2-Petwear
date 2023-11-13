using DataAccess;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp
{
    public class BookingManager
    {
        public void Create(Booking booking)
        {
            if (booking.Considerations.Equals("")){
                throw new Exception("Please type the fields correctly");
            }
            if (booking.CheckInDate >= booking.CheckOutDate)
            {
                throw new Exception("The CheckInDate must be earlier than CheckOutDate");
            }
            else
            {
                var bc = new BookingCrudFactory();
                bc.Create(booking);
            }
        }
        public void Update(Booking booking)
        {
            var bc=new BookingCrudFactory();
            bc.Update(booking);
        }
        public List<Booking> RetrieveAll()
        {
            var bc = new BookingCrudFactory();
            return bc.RetrieveAll<Booking>();
        }
        public Booking? RetrieveById (Booking booking)
        {
            var bc=new BookingCrudFactory();
            return bc.RetrieveById<Booking>(booking.Id);
        }
        public void Delete (Booking booking)
        {
            var bc=new BookingCrudFactory();
            bc.Delete(booking);
        }
    }
}
