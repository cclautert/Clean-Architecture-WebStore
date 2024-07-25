using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Product.Application.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [MinLength(3)]
        [MaxLength(200)]
        public string? Description { get;  set; }

        [Required(ErrorMessage = "The {0} is required")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Value")]
        public decimal Value { get;  set; }
    }
}
