using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Domain.Entities
{
    public class Product
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
    }

    public enum Category
    {
        None,
        Groceries,
        Electronics,
        Fashion
    }
}
