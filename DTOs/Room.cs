using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Room
    {
        private int idRoom {  get; set; }
        private string name {  get; set; }
        private string description {  get; set; }
        private int capacity {  get; set; }
        private float cost {  get; set; }
        private bool status {  get; set; }
    }
}
