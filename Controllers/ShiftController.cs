using API.Models.Requests.Shift;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        public ShiftController() { }
        [HttpPost]
        public async Task<ActionResult> StartShift(StartShiftRequest request)
        {
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> EndShift(EndShiftRequest request)
        {
            return Ok();
        }
    }
}
