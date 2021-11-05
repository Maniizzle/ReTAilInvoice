using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Domain.Entities
{
    public class DiscountType
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        public decimal Value { get; set; }

        public bool IsPercentage { get; set; }
        public long? CustomerTypeId { get; set; }
        public CustomerType CustomerType { get; set; }
    
    }

}
