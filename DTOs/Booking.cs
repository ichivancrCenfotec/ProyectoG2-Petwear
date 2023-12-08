using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{


    public class Booking : BaseDTO
    {

        
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Considerations { get; set; }
        public string? Status { get; set; }
        public int IdUser { get; set; }
        public int IdPet { get; set; }
        public int IdPackage { get; set; }

        public float TotalPrice { get; set; }

        public int IdBooking { get; set; }

    }
}
