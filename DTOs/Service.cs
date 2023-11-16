using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Service : BaseDTO
    {
        public int IdPackage { get; set; }

        public float Cost { get; set; }

        public string ServiceName { get; set; }

        public string Description { get; set; }
      
        public bool Availability { get; set; }

    }
}