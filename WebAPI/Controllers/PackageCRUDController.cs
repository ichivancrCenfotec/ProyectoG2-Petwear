using CoreApp;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageCRUDController : Controller
    {
      

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Package package)
        {
            var um = new PackageManager();

            try
            {
                um.Create(package);
                return Ok(package);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddService")]
        public async Task<IActionResult> AddService(Package_Service package_service)
        {
            var um = new PackageManager();

            try
            {
                
                um.AddService(package_service);
                return Ok(package_service);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet]
        [Route("RetrieveById")]
        public async Task<IActionResult> RetrieveById(int Id)
        {

            try
            {

                var um = new PackageManager();
                var package = new Package { IdPackage = Id };

                return Ok(um.RetrieveById(package));

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }

        
        [HttpGet]
        [Route("RetrieveAllById/{Id}")]
        public async Task<IActionResult> RetrieveAllById(int Id)
        {

            try
            {

                var um = new PackageManager();
                var package = new Package { IdPackage = Id };

                return Ok(um.RetrieveAllById(package));

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
                var um = new PackageManager();

                return Ok(um.RetrieveAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RetriveAllServices")]
        public async Task<IActionResult> RetriveAllServices()
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

        public async Task<IActionResult> Update(Package package)
        {

            var um = new PackageManager();

            try
            {
                um.Update(package);
                return Ok(package);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpDelete]
        [Route("Delete")]

        public async Task<IActionResult> Delete(Package package)
        {
            var um = new PackageManager();

            try
            {

                um.Delete(package);
                return Ok(package);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

    }

}

