using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Package: BaseDTO
    {
        public int TdPackage {  get; set; }
        public float Cost {  get; set; }
        public string Description {  get; set; }

    }
}
