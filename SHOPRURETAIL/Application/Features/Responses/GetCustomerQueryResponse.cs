using System;
using System.Collections.Generic;
using System.Text;

namespace SHOPRURETAIL.Application.Features.Responses
{
    public class GetCustomerQueryResponse
    {
        public long CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public long? CustomerTypeId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }


}
