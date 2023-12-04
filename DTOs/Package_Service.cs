using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Package_Service: BaseDTO
    {
        public int IDPackage_Service { get; set; }
        public int IdPackage { get; set; }
        public int IdService { get; set; }
    }
}
