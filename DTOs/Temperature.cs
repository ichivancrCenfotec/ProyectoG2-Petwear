using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Temperature : BaseDTO
    {
        private int idTemperature {  get; set; }
        private float value {  get; set; }
        private DateTime date {  get; set; }
    }
}
