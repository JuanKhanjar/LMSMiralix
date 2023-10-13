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
        public int AddedQuantity { get; set; }

        public virtual Group? Group { get; set; }
        public virtual PurchasedProduct? PurchasedProduct { get; set; }

        // Constructor for required properties
        public GroupProduct(int groupId,int purchasedProductId,int addedQuantity)
        {
            GroupId = groupId;
            PurchasedProductId = purchasedProductId;
            AddedQuantity = addedQuantity;
        }
        public GroupProduct()
        {
                
        }
        public static GroupProduct CreateGroupProduct(int groupId,int purchasedProductId,int addedQuantity)
        {
            var groupProduct = new GroupProduct
            {
                GroupId = groupId,
                PurchasedProductId = purchasedProductId,
                AddedQuantity = addedQuantity
            };
            return groupProduct;
        }
    }

}
