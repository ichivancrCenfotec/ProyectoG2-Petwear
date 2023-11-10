using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Room : BaseDTO
    {
        public int IdRoom {  get; set; }
        public string name {  get; set; }
        public string description {  get; set; }
        public int capacity {  get; set; }
        public float cost {  get; set; }
        public bool status {  get; set; }
    }
}
