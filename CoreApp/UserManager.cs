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
              //En general aqui se aplican las validaciones.

             */



            var uc = new UserCrudFactory();
            uc.Create(user);
        }


        

        public void Update(User user)
        {
            var uc = new UserCrudFactory();
            uc.Update(user);
        }

        public void ResetPassword(User user)
        {
            var uc = new UserCrudFactory();
            uc.ResetPassword(user);
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

        public object? RetrieveByEmail(User user)
        {
            var uc = new UserCrudFactory();
            return uc.RetrieveByEmail<User>(user.Email);
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

        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool PasswordOK (string password, string email, int id)
        {
            //Validamos que la contraseña sea la correcta parar el usuario.

            User user = RetrieveById(new User { Id = id }) as User; //Obtenemos el usuario por el id.


            if (user.Password == password && user.Email == email)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }
    }
}
