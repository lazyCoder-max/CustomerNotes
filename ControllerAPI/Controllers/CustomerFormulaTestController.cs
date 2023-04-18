using Application.CustomerFormulas.Commands.Get;
using Application.CustomerFormulaTests.Commands.Get;
using Microsoft.AspNetCore.Mvc;

namespace ControllerAPI.Controllers
{
    [ApiController]
    public class CustomerFormulaTestController : ApiControllerBase
    {
        [Route("api/customer-formula-test/get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAllFormulas([FromQuery] GetAllCustomerFormulaCommand query)
        {
            var pagedData = await Mediator.Send(query);
            return Ok(pagedData);
        }

        [Route("api/customer-formula-test/get-ByCustomerNumber")]
        [HttpGet]
        public async Task<IActionResult> GetFormulaTest([FromQuery] GetCustomerFormulaTestByCustomerNumberCommand query)
        {
            var pagedData = await Mediator.Send(query);
            return Ok(pagedData);
        }

        [Route("api/customer-formula-test/get-ByFormulaName")]
        [HttpGet]
        public async Task<IActionResult> GetFormulaTest([FromQuery] GetCustomerFormulaTestByFormulaNameCommand query)
        {
            var pagedData = await Mediator.Send(query);
            return Ok(pagedData);
        }
    }
}
