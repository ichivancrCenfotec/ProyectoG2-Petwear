using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
<<<<<<< HEAD
    public class Booking:BaseDTO
    {
        public int IdPet {  get; set; }
        public int IdPayment { get; set; }
        public int IdPackage { get; set; }
=======
    public class Booking: BaseDTO
    {

        public int IdBooking {  get; set; }
>>>>>>> 6a4bbcea2771d1285370a82851a4f39bfce07f53
        public DateTime CheckInDate {  get; set; }
        public DateTime CheckOutDate {  get; set; }
        public string Considerations {  get; set; }
        public bool Status {  get; set; }
<<<<<<< HEAD
=======

>>>>>>> 6a4bbcea2771d1285370a82851a4f39bfce07f53
    }
}
