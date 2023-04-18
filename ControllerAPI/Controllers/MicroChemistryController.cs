using Application.Customers.Commands.GetCustomer;
using Application.MicroChemistry.Commands.GetMicroChemistry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControllerAPI.Controllers
{
    [ApiController]
    public class MicroChemistryController : ApiControllerBase
    {
        [Route("api/microchemistry/get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAllMicroChemistry([FromQuery] GetAllMicroChemistryCommand query)
        {
            var pagedData = await Mediator.Send(query);
            return Ok(pagedData);
        }
        [Route("api/microchemistry/get-allType")]
        [HttpGet]
        public async Task<IActionResult> GetAllMicroChemistryType([FromQuery] GetAllMicroChemistryTypeCommand query)
        {
            var pagedData = await Mediator.Send(query);
            return Ok(pagedData);
        }

        [Route("api/microchemistry/get-ByType")]
        [HttpGet]
        public async Task<IActionResult> GetAllMicroChemistryByType([FromQuery] GetMicroChemistryByTypeCommand query)
        {
            var pagedData = await Mediator.Send(query);
            return Ok(pagedData);
        }
        [Route("api/microchemistry/get-ByTestNumber")]
        [HttpGet]
        public async Task<IActionResult> GetMicroChemistryByTestNumber([FromQuery] GetMicroChemistryByTestNumberCommand query)
        {
            var pagedData = await Mediator.Send(query);
            return Ok(pagedData);
        }
    }
}
