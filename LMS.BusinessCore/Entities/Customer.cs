using System.ComponentModel.DataAnnotations;

namespace LMS.BusinessCore.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer name is required")]
        public string CustomerName { get; set; }

        // Navigation properties should use collection interfaces
        public virtual ICollection<PurchasedProduct> PurchasedProducts { get; set; } = new List<PurchasedProduct>();
        public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
    }

}
