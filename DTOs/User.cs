using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class User : BaseDTO
    {
        public string? Name {  get; set; }
        public string? LastName {  get; set; }
        public string? Password {  get; set; }
        public string? Email {  get; set; }
        public string? Address {  get; set; }
        public string? Role { get; set; }
        public int PhoneNumber { get; set; }

        public string? ValidationOTP { get; set; }
        public string? ResetOTP { get; set; }

        //falta foto


    }
}
