using CoreApp;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingCRUDController : ControllerBase
    {
        [HttpPost]

        [Route("Create")]
        public async Task<IActionResult> Create(Booking booking)
        {

            var bm = new BookingManager();

            try
            {
                bm.Create(booking);
                return Ok(booking);
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
                var bm = new BookingManager();

                return Ok(bm.RetrieveAll());
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
                var bm = new BookingManager();
                var booking = new Booking { Id = id };

                return Ok(bm.RetrieveById(booking));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Booking booking)
        {

            var bm = new BookingManager();

            try
            {
                bm.Update(booking);
                return Ok(booking);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Booking booking)
        {

            var bm = new BookingManager();

            try
            {
                bm.Delete(booking);
                return Ok(booking);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveAllById")]
        public async Task<IActionResult> RetrieveAllById(int Id)
        {

            try
            {

                var um = new BookingManager();
                var booking = new Booking { IdBooking = Id };

                return Ok(um.RetrieveAllById(booking));

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }
    }
}
