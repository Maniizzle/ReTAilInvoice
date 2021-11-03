using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SHOPRURETAIL.Application.Features.Customers.Commands;
using SHOPRURETAIL.Application.Features.Customers.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : BaseApiController
    {

        [HttpPost("create")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand customerDto)
        {
          return CreatedAtAction(nameof(CreateCustomer),  await Mediator.Send(customerDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            return Ok( await Mediator.Send(new GetCustomerByIdQuery() {Id=id }));
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerByName([FromQuery] GetCustomerByParameterQuery query)
        {
            return Ok(await Mediator.Send(query));

        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllCustomer([FromQuery]GetAllCustomersQuery query)
        {
            return Ok(await Mediator.Send(query));

        }
    }
}
