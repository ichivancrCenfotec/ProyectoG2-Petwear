using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Coupon
    {
        public string? CodeCoupon {  get; set; }

        public int? UserId { get; set; }

        public double? ValorTotal { get; set; }
    }
}
