using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Domain.Entities

{
    public class InvoiceDetail
    {
        [Key]
        
        public long Id { get; set; }

        [Required] 
        public long ProductId { get; set; }

        public Customer Product { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        [Required]
        public decimal ProductUnitPrice { get; set; }

        [Required]
        [MaxLength(30)]
        public int ProductQuantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(19, 2)")]
        public decimal DerivedProductCost { get; set; } 

        
        [Required]
        [Column(TypeName = "decimal(19, 2)")]
        public decimal TotalDerivedCost { get; set; }

        [ForeignKey(nameof(Invoice))]
        public int InvoiceId { get; set; }

        public Invoice Invoice { get; set; } 
    }
}
