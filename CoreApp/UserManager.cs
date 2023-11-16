using DataAccess;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoreApp
{
    public class UserManager
    {

        public void Create(User user)
        {
            //Validar que los campos este completos en el user.
            /*

             if (string.IsNullOrEmpty(user.Name))
             {
                 throw new Exception("Name is required");
             }

             if (!IsValidPassword(user.Password))
             {
                 throw new Exception("The password does not meet the required criteria. It must be at least 8 characters long and include" +
                     " at least one uppercase letter, one lowercase letter, one digit, and one special character (e.g., !, @, #, $, etc.).");
             }
             */

            //En general aqui se aplican las validaciones.
            if (IsOver18(user))
            {
                //Despues de validar, se envia la información a la base de datos.
                var uc = new UserCrudFactory();
                uc.Create(user);
            }
            else
            {
                throw new Exception("User must be 18 years old.");
            }

        }

        public void Update(User user)
        {
            var uc = new UserCrudFactory();
            uc.Update(user);
        }


        public void Delete(User user)
        {
            var uc = new UserCrudFactory();
            uc.Delete(user);
        }


        public object? RetrieveAll()
        {
            var uc = new UserCrudFactory();
            return uc.RetrieveAll<User>();
        }

        public object? RetrieveById(User user)
        {
            var uc = new UserCrudFactory();
            return uc.RetrieveById<User>(user.Id);
        }

        //Validar contraseña
        public bool IsValidPassword(string password)
        {

            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            {
                return false;
            }

            bool hasUpperCaseLetter = false;
            bool hasLowerCaseLetter = false;
            bool hasDigit = false;
            bool hasSpecialChar = new Regex("[^a-zA-Z0-9]").IsMatch(password);

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpperCaseLetter = true;
                else if (char.IsLower(c)) hasLowerCaseLetter = true;
                else if (char.IsDigit(c)) hasDigit = true;
            }

            return hasUpperCaseLetter && hasLowerCaseLetter && hasDigit && hasSpecialChar;

        }

        // Calcular la edad del usuario
        public bool IsOver18(User user)
        {
            DateTime currentDate = DateTime.Now;

            int age = currentDate.Year - user.BirthDate.Year;

            // If the user hasn't had their birthday yet this year, subtract 1 from age
            if (user.BirthDate.Date > currentDate.AddYears(-age).Date)
            {
                age--;
            }

            return age >= 18;
        }

    }
}
