using CoreApp;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IDEAController : ControllerBase
    {

        [HttpGet]
        [Route("RetriveAll")]
        public async Task<IActionResult> RetriveAll()
        {
            try
            {
                var pd = new IDEAManager();

                return Ok(pd.RetrieveAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        public PetData PostPetData(PetData pd)
        {
            return pd;
        }
    }
}