using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.BusinessCore.Entities
{
    public class PurchasedProduct
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Product price is required")]
        [Range(0.01,double.MaxValue,ErrorMessage = "Product price must be greater than 0")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ProductPrice { get; set; }

        [Required(ErrorMessage = "Purchased quantity is required")]
        public int PurchasedQty { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }

        // Computed Property for Total Cost
        public decimal SubTotal
        {
            get
            {
                return ProductPrice * PurchasedQty;
            }
        }
    }

}
