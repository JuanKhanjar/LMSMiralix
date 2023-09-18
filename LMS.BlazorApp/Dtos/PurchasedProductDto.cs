namespace LMS.BlazorApp.Dtos
{
    public class PurchasedProductDto
    {
        public int PurchasedProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int PurchasedQty { get; set; }
        public int CustomerId { get; set; }
        public int InputPurchasedtQuantity { get; set; }
        public int CompareValue { get; set; }
    }
}
