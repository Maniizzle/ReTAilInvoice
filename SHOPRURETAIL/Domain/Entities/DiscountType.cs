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
        [MaxLength(55)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(19, 2)")]
        public decimal Value { get; set; }

        public bool IsPercentage { get; set; }
    
    }
}
