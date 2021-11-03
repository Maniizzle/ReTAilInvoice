using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Application.Features.Responses
{
    public class GetDiscountQueryResponse
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public decimal Value { get; set; }
        public bool IsPercentage { get; set; }
    }
}
