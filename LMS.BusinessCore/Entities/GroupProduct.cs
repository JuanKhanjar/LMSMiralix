using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        // Navigation properties should be nullable
        public virtual Group? Group { get; set; }        
        public virtual PurchasedProduct? PurchasedProduct { get; set; }
    }
}
