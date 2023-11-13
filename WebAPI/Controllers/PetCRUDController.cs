using CoreApp;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCRUDController : ControllerBase
    {
        ///Controlador de mantenimiento del usuario.
        ///C -> Create (post)
        ///R -> Retrieve (get)
        ///U -> Update (put)
        ///D -> Delete (delete)

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Pet pet)
        {
            var pm = new PetManager();

            try
            {
                pm.Create(pet);
                return Ok(pet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet]
        [Route("RetrieveById")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            try
            {
                var pm = new PetManager();
                var pet = new Pet { Id = id };

                return Ok(pm.RetrieveById(pet));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveAll")]
        public async Task<IActionResult> RetrieveAll()
        {
            try
            {
                var pm = new PetManager();

                return Ok(pm.RetrieveAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
