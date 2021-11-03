using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SHOPRURETAIL.Application.Features.Invoices.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Controllers
{
    [Route("api/invoices")]
    [ApiController]
    public class InvoiceController : BaseApiController
    {

        [HttpPost("create")]
        public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceCommand invoiceDto)
        {
            return CreatedAtAction(nameof(CreateInvoice), await Mediator.Send(invoiceDto));
        }


    }
}
