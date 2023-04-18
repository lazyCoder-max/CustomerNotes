using Application.CustomerFormulas.Commands.Get;
using Microsoft.AspNetCore.Mvc;

namespace ControllerAPI.Controllers
{
    [ApiController]
    public class CustomerFormulaController : ApiControllerBase
    {
        [Route("api/customer-formula/get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAllFormulas([FromQuery] GetAllCustomerFormulaCommand query)
        {
            var pagedData = await Mediator.Send(query);
            return Ok(pagedData);
        }
        [Route("api/customer-formula/get-ByCustomerNumber")]
        [HttpGet]
        public async Task<IActionResult> GetAllFormulas([FromQuery] GetCustomerFormulaByCustomerNumberCommand query)
        {
            var pagedData = await Mediator.Send(query);
            return Ok(pagedData);
        }
    }
}
