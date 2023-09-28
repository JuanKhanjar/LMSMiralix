using LMS.BlazorApp.Dtos;

namespace LMS.BlazorApp.Extensions
{
    public static class GroupProductDtoExtensions
    {
        public static decimal CalculateTotalPrice(this Dtos.GroupProductDto groupProduct)
        {
            return groupProduct.ProductPrice * groupProduct.AddedQty;
        }
        public static int CalculateTotalQuantity(this GroupDto group)
        {
            return group.GroupProductsDto.Sum(gp => gp.AddedQty);
        }
        public static decimal CalculateTotalPrice(this PurchasedProductDto purchasedProduct)
        {
            return purchasedProduct.ProductPrice * purchasedProduct.PurchasedQty;
        }

        public static decimal CalculateTotalPrice(this GroupDto group)
        {
            return group.GroupProductsDto.Sum(gp => gp.CalculateTotalPrice());
        }
        public static decimal CalculateTotalAmount<T>(this IEnumerable<T> items, Func<T, decimal> priceSelector)
        {
            return items.Sum(priceSelector);
        }
    }
}
