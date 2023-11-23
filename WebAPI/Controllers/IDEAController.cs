using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IDEAController : ControllerBase
    {
        [HttpGet]
        public PetData getStringTest()
        {
            return new PetData(){Name = "Jaimito"};
        }

        [HttpPost]
        public PetData PostTest(PetData pd)
        {
            pd.Name = "Recibido: " + pd.Name;


            return pd;
        }
    }
}
