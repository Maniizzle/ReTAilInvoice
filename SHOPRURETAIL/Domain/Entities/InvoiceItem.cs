using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Domain.Entities

{
    public class InvoiceItem
    {
        [Key]
        
        public long Id { get; set; }

        [Required] 
        public long ProductId { get; set; }

        public Product Product { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        [Required]
        public decimal ProductUnitPrice { get; set; }

        public Category ProduuctCategory { get; set; }

        [Required]
        [MaxLength(30)]
        public int ProductQuantity { get; set; }


        [Required]
        public decimal TotalCost { get; set; }

        [ForeignKey(nameof(Invoice))]
        public int InvoiceId { get; set; }

        public Invoice Invoice { get; set; } 
    }
}
