using LMS.BusinessUseCases.Dtos.PurchaseProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BusinessUseCases.Extensions.PurchasedProductEX
{
    public static class PurchasedProductDtoExtensions
    {
        // Extension method to calculate the total quantity of all PurchasedProducts.
        public static int CalculateTotalQuantity(this IEnumerable<PurchasedProductDto> products)
        {
            if (products == null)
                throw new ArgumentNullException(nameof(products));

            return products.Sum(p => p.PurchasedQty);
        }

        // Extension method to calculate the subtotal for each PurchasedProduct.
        public static decimal CalculateSubtotal(this PurchasedProductDto product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            return product.ProductPrice * product.PurchasedQty;
        }

        // Extension method to calculate the total price for all PurchasedProducts.
        public static decimal CalculateTotalPrice(this IEnumerable<PurchasedProductDto> products)
        {
            if (products == null)
                throw new ArgumentNullException(nameof(products));

            return products.Sum(p => p.CalculateSubtotal());
        }
    }
}
