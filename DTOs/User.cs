using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class User : BaseDTO
    {
        private string name {  get; set; }
        private string lastName {  get; set; }
        private string password {  get; set; }
        private string email {  get; set; }
        private string address {  get; set; }
        private string role { get; set; }
        private int phoneNumber { get; set; }

    }
}
