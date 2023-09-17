namespace LMS.BlazorApp.Dtos
{
    public class GroupProductDto
    {
        public int GroupId { get; set; }
        public int PurchasedProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int AddedQty { get; set; }
        public int InputProductQuantity { get; set; }
       
    }
}
