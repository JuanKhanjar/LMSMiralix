using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.BusinessCore.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Product price must be greater than 0")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ProductPrice { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Purchased quantity must be non-negative")]
        public int PurchasedQty { get; set; }

        public int CustomerId { get; set; }

        // Navigation property
        public Customer Customer { get; set; }
        public List<GroupProduct> GroupProducts { get; set; }
    }
}
