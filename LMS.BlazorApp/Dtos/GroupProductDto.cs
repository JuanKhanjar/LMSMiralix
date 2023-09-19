namespace LMS.BlazorApp.Dtos
{
    public class GroupProductDto
    {
        public int GroupId { get; set; }
        public int PurchasedProductId { get; set; }
        public string ProductName { get; set; }=string.Empty;
        public decimal ProductPrice { get; set; }
        public int AddedQty { get; set; }
        public int InputProductQuantity { get; set; }
        public int PPAvailability { get; set; }

        // Method to update PPAvailability based on a list of PurchasedProductDto
        public int GetPPAvailability(List<PurchasedProductDto> purchasedProducts)
        {
            PurchasedProductDto PP = purchasedProducts.FirstOrDefault(pp => pp.PurchasedProductId == PurchasedProductId);
            PPAvailability = PP?.PurchasedQty ?? 0;
            return PPAvailability;
        }

    }
}
