using API.Models.Entity;
using API.Models.Requests.Employee;
using API.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public EmployeeController() { }


        [HttpPost]
        public async Task<ActionResult<EmployeeResponse>> Add(AddEmployeeRequest request)
        {
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult<EmployeeResponse>> Update(UpdateEmployeeRequest request)
        {
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(DeleteEmployeeRequest request)
        {
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<ICollection<EmployeeWithStatsResponse>>> GetEmployees(GetEmployeeRequest request)
        {
            return Ok();
        }
        [HttpGet("Posts")]
        public async Task<ActionResult<ICollection<PostResponse>>> GetPosts()
        {
            return Ok();
        }
    }
}
