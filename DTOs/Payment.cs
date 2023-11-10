using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Payment : BaseDTO
    {
        private int IdPayment { get; set; }
        private string Description { get; set; }
        private string PaymenteMethod { get; set; }

    }
}
