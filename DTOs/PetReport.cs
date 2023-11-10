using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PetReport : BaseDTO
    {
        public int IdPetReport { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int IdPet { get; set; }
    
        

    }
}
