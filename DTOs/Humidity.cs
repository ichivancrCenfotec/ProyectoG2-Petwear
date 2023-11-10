using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Humidity : BaseDTO
    {
        public int IdHumidity {  get; set; }
        public float Value {  get; set; }
        public DateTime Date {  get; set; }
       
    }
}
