using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Domain.Entities

{
    public class Invoice
    {
        public Invoice()
        {
            DateCreated = DateTime.Now;
            InvoiceNumber = Guid.NewGuid().ToString();
        }
        [Key]
        public int InvoiceId { get; set; }

        [Required]
        public string InvoiceNumber { get; set; }
        
        public string DiscountTypes { get; set; }
        public string DiscountRates { get; set; }

        public decimal TotalDiscount { get; set; }

        public DateTime DateCreated { get; set; }
        [Required]
        public decimal SubTotalCost { get; set; }
        public decimal TotalCost { get; set; }

        public long CustomerId { get; set; }
        public Customer Customers { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
