using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Pet: BaseDTO
    {
        private int IdPet {  get; set; }
        private string NamePet {  get; set; }
        private int Age {  get; set; }
        private string Breed {  get; set; }
        private int Weight {  get; set; }
        private string Description {  get; set; }
        private int LevelAggressiveness {  get; set; }

    }
}
