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
        public virtual ICollection<PurchasedProduct> PurchasedProducts { get; set; } = new List<PurchasedProduct>( );
        public virtual ICollection<Group> Groups { get; set; } = new List<Group>( );

        // Additional properties
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Registration Date")]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        // Custom methods
        public void AddPurchasedProduct(PurchasedProduct product)
        {
            PurchasedProducts.Add(product);
        }

        public void JoinGroup(Group group)
        {
            Groups.Add(group);
        }

        public void LeaveGroup(Group group)
        {
            Groups.Remove(group);
        }
        public int GetTotalPurchasedProducts()
        {
            return PurchasedProducts.Count;
        }

        public decimal CalculateTotalPurchasedProductsCost()
        {
            decimal totalCost = 0;

            foreach (var product in PurchasedProducts)
            {
                totalCost += product.ProductPrice * product.PurchasedQty;
            }

            return totalCost;
        }

        // Custom validation
        public bool IsValidCustomer()
        {
            return !string.IsNullOrWhiteSpace(CustomerName) && !string.IsNullOrWhiteSpace(Email);
        }
    }

}
