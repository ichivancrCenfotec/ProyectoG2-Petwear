using CoreApp;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCRUDController : ControllerBase
    {
        ///Controlador de mantenimiento del servicio.
        ///C -> Create (post)
        ///R -> Retrieve (get)
        ///U -> Update (put)
        ///D -> Delete (delete)

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Service service)
        {
            var um = new ServiceManager();

            try
            {
                um.Create(service);
                return Ok(service);
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
                var um = new ServiceManager();
                var service = new Service { Id = id };

                return Ok(um.RetrieveById(service));

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
                var um = new ServiceManager();

                return Ok(um.RetrieveAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpPut]
        [Route("Update")]

        public async Task<IActionResult> Update(Service service)
        {

            var um = new ServiceManager();

            try
            {
                um.Update(service);
                return Ok(service);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpDelete]
        [Route("Delete")]

        public async Task<IActionResult> Delete(Service service)
        {
            var um = new ServiceManager();

            try
            {

                um.Delete(service);
                return Ok(service);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

    }
}
