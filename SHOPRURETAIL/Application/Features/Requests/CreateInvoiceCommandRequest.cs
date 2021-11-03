using SHOPRURETAIL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Application.Features.Requests
{
    public class CreateInvoiceCommandRequest
    {
        [Required]
        [Range(1,long.MaxValue)]
        public long CustomerId { get; set; }

        [Required]
        public List<InvoiceDetailsRequest> InvoiceDetails { get; set; }
    }


    public class InvoiceDetailsRequest
    {
        [Required]
        [Range(1,long.MaxValue)]
        public long ProductId { get; set; }

        [Required]
        [Range(1,long.MaxValue)]
        public int ProductQuantity { get; set; }

    }


}
