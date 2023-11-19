using CoreApp;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WebAPI.services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCRUDController : ControllerBase
    {
        ///Controlador de mantenimiento del usuario.
        ///C -> Create
        ///R -> Retrieve
        ///U -> Update
        ///D -> Delete


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(User user)
        {
            var um = new UserManager();
            EmailSender emailSender = new EmailSender();   


            try
            {
                um.Create(user);
                emailSender.SendEmail(user.Email, user.Name, user.Password).Wait();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("ResetPassword")]

        public async Task<IActionResult> ResetPassword(User user)
        {

            var um = new UserManager();

            try
            {
                um.ResetPassword(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        [Route("LogIn")]
        public async Task<IActionResult> LogIn(User request)
        {

            string email = request.Email;
            string password = request.Password;


            try
            {
                var um = new UserManager();
                var user =new User { Email = email };
                User user1 = (User)um.RetrieveByEmail(user);
            

                if (VerifyPassword(password, user1))
                {
                    return Ok("Welcome");
                    return RedirectToAction("Index", "Home");

                    
                }
                else
                {
                    return StatusCode(500, "Wrong Password");
                }
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
          
        }

        private bool VerifyPassword(string password, User user)
        {
            var userPassword = user.Password;
            
            if (password == userPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
            

        }

   



        [HttpGet]
        [Route("RetrieveById")]
        public IActionResult RetrieveById(int id)
        {

            try
            {

                var um = new UserManager();
                var user = new User { Id = id };

                return Ok(um.RetrieveById(user));

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }

        [HttpGet]
        [Route("RetriveAll")]
        public async Task<IActionResult> RetriveAll()
        {

            try
            {
                var um = new UserManager();

                return Ok(um.RetrieveAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]

        public async Task<IActionResult> Update(User user)
        {

            var um = new UserManager();

            try
            {
                um.Update(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpDelete]
        [Route("Delete")]

        public async Task<IActionResult> Delete(User user)
        {
            var um = new UserManager();

            try
            {

                um.Delete(user);
                return Ok(user);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

    }
}
