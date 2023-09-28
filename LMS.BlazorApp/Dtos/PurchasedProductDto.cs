using LMS.BusinessCore.Entities;

namespace LMS.BlazorApp.Dtos
{
    public class PurchasedProductDto
    {
        public int PurchasedProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal ProductPrice { get; set; }
        public int PurchasedQty { get; set; }
        public int CustomerId { get; set; }
        public int InputPurchasedtQuantity { get; set; }
        public int GPAvailability { get; set; }

        // Method to update GPAvailability based on a list of GroupProductDto
        public int GetGPAvailability(List<GroupProductDto> groupProducts)
        {
            if (groupProducts != null)
            {
                GroupProductDto GP = groupProducts.FirstOrDefault(gp => gp.PurchasedProductId == PurchasedProductId);
                GPAvailability = GP?.InputProductQuantity ?? 0;
                return GPAvailability;
            }
            return 0;

            
        }
    }
}
