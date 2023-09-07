using System.ComponentModel.DataAnnotations;

namespace LMS.BusinessCore.Entities
{
    public class GroupProduct
    {
        [Key]
        public int GroupProductId { get; set; }

        public int GroupId { get; set; }
        public int PurchasedProductId { get; set; }

        [Required(ErrorMessage = "Added quantity must be at least 1")]
        [Range(1, int.MaxValue, ErrorMessage = "Added quantity must be at least 1")]
        public int AddedQuantity { get; set; }

        // Navigation properties
        public virtual Group Group { get; set; } = new Group();
        public virtual PurchasedProduct Product { get; set; } = new PurchasedProduct();
    }
}
