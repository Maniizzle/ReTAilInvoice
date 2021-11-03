using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Domain.Entities
{
    public class Customer
    {
        public Customer()
        {
            DateCreated = DateTime.Now;
        }
        public Customer(DateTime dateTime)
        {
            DateCreated = dateTime;
        }
        [Key]
        public long CustomerId { get; set; }
        
        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }
        
        [MaxLength(25)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [MaxLength(30)] 
        public string Email { get; set; }

        [Required]
        [MaxLength(13)]
        public string PhoneNumber { get; set; }

        public long? CustomerTypeId { get; set; }
        
        public virtual CustomerType CustomerType { get; set; }
        
        public DateTime DateCreated { get; }  
    }
}
