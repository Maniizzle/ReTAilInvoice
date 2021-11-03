using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHOPRURETAIL.Domain.Entities
{
    public class CustomerType
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
