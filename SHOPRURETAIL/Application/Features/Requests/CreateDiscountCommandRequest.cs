using System.ComponentModel.DataAnnotations;

namespace SHOPRURETAIL.Application.Requests
{
    public class CreateDiscountCommandRequest
    {
        [Required]
        public string Name { get; set; }
        public long? CustomerTypeId { get; set; }

        [Required]
        [Range(1,double.MaxValue)]
        public decimal Value { get; set; }

        public bool IsPercentage { get; set; }

    }
}
