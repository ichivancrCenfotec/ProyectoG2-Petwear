using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Pet: BaseDTO
    {
        private int idPet {  get; set; }
        private string namePet {  get; set; }
        private int age {  get; set; }
        private string breed {  get; set; }
        private int weight {  get; set; }
        private string description {  get; set; }
        private int levelAggressiveness {  get; set; }

    }
}
