using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Booking
    {
        public int idBooking {  get; set; }
        public DateTime checkInDate {  get; set; }
        public DateTime checkOutDate {  get; set; }
        public string considerations {  get; set; }
        public bool status {  get; set; }
    }
}
