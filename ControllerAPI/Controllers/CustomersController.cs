using Application.Customers.Commands.GetCustomer;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControllerAPI.Controllers
{
    
    [ApiController]
    public class CustomersController : ApiControllerBase
    { 
        [Route("api/customer/get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers([FromQuery] GetAllCustomersCommnd query)
        {
            var pagedData = await Mediator.Send(query);
            return Ok(pagedData);
        }
        [Route("api/customer/get-ById")]
        [HttpGet]
        public async Task<IActionResult> GetCustomerById([FromQuery] GetCustomerByIdCommand query)
        {
            var pagedData = await Mediator.Send(query);
            return Ok(pagedData);
        }
        [Route("api/customer/get-BySearchKey")]
        [HttpGet]
        public async Task<IActionResult> GetCustomerBySearchKey([FromQuery] GetCustomerBySearchKeyCommand query)
        {
            var pagedData = await Mediator.Send(query);
            return Ok(pagedData);
        }
        [Route("api/customer/get-ByRegion")]
        [HttpGet]
        public async Task<IActionResult> GetCustomerByRegion([FromQuery] GetCustomerByRegionCommand query)
        {
            var pagedData = await Mediator.Send(query);
            return Ok(pagedData);
        }
    }

}
