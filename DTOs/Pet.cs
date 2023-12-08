using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Pet: BaseDTO
    {
        public int idPet {  get; set; }
        public string? NamePet {  get; set; }
        public int Age {  get; set; }
        public string? Breed {  get; set; }
        public float Weight {  get; set; }
        public string? Description {  get; set; }
        public int LevelAggressiveness {  get; set; }
        public string? FotoUno { get; set; }
        public string? FotoDos { get; set; }
        public int idRoom { get; set; }

        //Constructor
        public Pet()
        {
            idPet = 0;
            NamePet = null;
            Age = 0;
            Breed = null;
            Weight = 0;
            Description = null;
            LevelAggressiveness = 0;
            FotoUno = null;
            FotoDos = null;
        }
    }
}
