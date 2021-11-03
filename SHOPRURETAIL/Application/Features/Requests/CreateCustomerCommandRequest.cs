using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Application.Requests
{
    public class CreateCustomerCommandRequest
    {
        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required]
        [MinLength(8)]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }

        public long? CustomerTypeId { get; set; }

    }
}
