using System.ComponentModel.DataAnnotations;

namespace LMS.BusinessCore.Entities
{
    public class GroupProduct
    {
        [Key]
        public int GroupProductId { get; set; }

        public int GroupId { get; set; }
        public int ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Added quantity must be at least 1")]
        public int AddedQuantity { get; set; }

        // Navigation properties
        public Group Group { get; set; }
        public Product Product { get; set; }
    }
}
