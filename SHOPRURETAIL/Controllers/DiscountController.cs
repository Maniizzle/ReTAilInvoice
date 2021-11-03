using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SHOPRURETAIL.Application.Features.Discounts.Commands;
using SHOPRURETAIL.Application.Features.Discounts.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Controllers
{
    [Route("api/discounts")]
    [ApiController]
    public class DiscountController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllDiscount([FromQuery] GetAllDiscountQuery query)
        {
            return Ok(await Mediator.Send(query));

        }

        [HttpGet("{type}")]
        public async Task<IActionResult> GetDiscountPercentageByType([Required][StringLength(100, MinimumLength = 1)] string type)
        {
            return Ok(await Mediator.Send( new GetDiscountPercentageByTypeQuery { Type= type }));

        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateDiscount([FromBody] CreateDiscountCommand customerDto)
        {
            return CreatedAtAction(nameof(CreateDiscount), await Mediator.Send(customerDto));
        }


    }
}
