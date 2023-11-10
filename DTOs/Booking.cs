using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Booking:BaseDTO
    {
        public int IdPet {  get; set; }
        public int IdPayment { get; set; }
        public int IdPackage { get; set; }
        public DateTime CheckInDate {  get; set; }
        public DateTime CheckOutDate {  get; set; }
        public string Considerations {  get; set; }
        public bool Status {  get; set; }
    }
}
