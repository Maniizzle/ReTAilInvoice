using System.ComponentModel.DataAnnotations;

namespace SHOPRURETAIL.Application.Requests
{
    public class CreateDiscountCommandRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Value { get; set; }

        public bool IsPercentage { get; set; }

    }
}
