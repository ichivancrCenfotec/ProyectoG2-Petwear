using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Booking
    {
        private int idBooking {  get; set; }
        private DateTime checkInDate {  get; set; }
        private DateTime checkOutDate {  get; set; }
        private string considerations {  get; set; }
        private bool status {  get; set; }
    }
}
