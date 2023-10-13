using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace LMS.BusinessCore.Entities
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        [Required(ErrorMessage = "Group name is required")]
        public string GroupName { get; set; }

        
        public string EAN { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }

        public virtual ICollection<GroupProduct> GroupProducts { get; set; } = new List<GroupProduct>( );

        public Group()
        {
            
        }
        // Constructor for required properties
        public Group(string groupName,int customerId)
        {
            GroupName = groupName;
            CustomerId = customerId;
            GenerateEAN( );
        }
        public static Group CreateGroup(string groupName,int customerId)
        {
            var group = new Group(groupName,customerId);
            return group;
        }
        // Method to add a product to the group
        public void AddProductToGroup(GroupProduct product)
        {
            GroupProducts.Add(product);
        }

        // Method to remove a product from the group
        public void RemoveProductFromGroup(GroupProduct product)
        {
            GroupProducts.Remove(product);
        }

        // Custom validation for EAN
        public bool IsEANValid()
        {
            return string.IsNullOrEmpty(EAN);
        }

        public int GetTotalGroupProductCount()
        {
            return GroupProducts.Count;
        }
        public decimal GetTotalGroupProductTotal()
        {
            decimal total = 0;

            foreach (var product in GroupProducts)
            {
                if (product.PurchasedProduct != null)
                {
                    total += product.PurchasedProduct.ProductPrice * product.AddedQuantity;
                }
            }

            return total;
        }


        private void GenerateEAN()
        {
            if (!string.IsNullOrEmpty(GroupName) && Customer != null)
            {
                string customerNameInitials = Customer.CustomerName.Substring(0,2);
                string year = DateTime.Now.Year.ToString( ).Substring(2);
                string randomDigits = GenerateRandomDigits(4);

                EAN = $"{GroupName.Substring(0,3)}{randomDigits}{customerNameInitials}{year}";
            }
        }

        // Helper method to generate random digits
        private string GenerateRandomDigits(int digitCount)
        {
            Random random = new Random( );
            StringBuilder randomDigits = new StringBuilder( );

            for (int i = 0; i < digitCount; i++)
            {
                randomDigits.Append(random.Next(10));
            }

            return randomDigits.ToString( );
        }
    }

}
