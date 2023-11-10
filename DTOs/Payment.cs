using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Payment : BaseDTO
    {
        public int IdPayment { get; set; }
        public string Description { get; set; }
        public string PaymenteMethod { get; set; }

    }
}
