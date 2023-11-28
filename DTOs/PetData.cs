using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PetData : BaseDTO
    {
        public int IdPet { get; set; }

        public float Temperature { get; set; }

        public int Humidity { get; set; }
        public float UltraViolet { get; set; }

        public DateTime Created { get; set; }
    }
}