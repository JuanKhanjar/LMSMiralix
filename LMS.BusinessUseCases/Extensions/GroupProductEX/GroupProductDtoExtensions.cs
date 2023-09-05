using LMS.BusinessUseCases.Dtos.GroupProducts;

namespace LMS.BusinessUseCases.Extensions.GroupProductEX
{
    public static class GroupProductDtoExtensions
    {
        // Extension method to calculate the total quantity of all GroupProductDto items.
        public static int CalculateTotalQuantity(this IEnumerable<GroupProductDto> groupProducts)
        {
            if (groupProducts == null)
                throw new ArgumentNullException(nameof(groupProducts));

            return groupProducts.Sum(gp => gp.AddedQuantity);
        }

        // Extension method to calculate the subtotal for each GroupProductDto item.
        public static decimal CalculateSubtotal(this GroupProductDto groupProduct)
        {
            if (groupProduct == null)
                throw new ArgumentNullException(nameof(groupProduct));

            // You can add more logic here if needed to calculate subtotal.
            // For example, if you have product prices associated with GroupProductDto.
            return groupProduct.AddedQuantity * GetProductPrice(groupProduct.ProductId);
        }

        // Extension method to calculate the total price for all GroupProductDto items.
        public static decimal CalculateTotalPrice(this IEnumerable<GroupProductDto> groupProducts)
        {
            if (groupProducts == null)
                throw new ArgumentNullException(nameof(groupProducts));

            return groupProducts.Sum(gp => gp.CalculateSubtotal());
        }

        // Replace this with the actual method to get product price based on ProductId.
        private static decimal GetProductPrice(int productId)
        {
            // Add your logic to retrieve the product price based on productId.
            // This is a placeholder method, and you should replace it with the actual implementation.
            // Example: You might fetch the product price from a database or a service.
            return 0.0m; // Placeholder value.
        }
    }
}
