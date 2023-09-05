using LMS.BusinessCore.Entities;
using LMS.BusinessUseCases.Dtos.PurchaseProducts;
using LMS.BusinessUseCases.PluginsInterfaces;
using LMS.BusinessUseCases.PurchasedProductsUC.PurchasedProductUCInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BusinessUseCases.PurchasedProductsUC
{
    public class GetPurchasedProductsByCustomerIdUC : IGetPurchasedProductsByCustomerIdUC
    {
        private readonly IPurchasedProductRepository _purchasedProductRepository;

        public GetPurchasedProductsByCustomerIdUC(IPurchasedProductRepository purchasedProductRepository)
        {
            _purchasedProductRepository = purchasedProductRepository;
        }

        public async Task<IEnumerable<PurchasedProductDto>> ExecuteAsync(int customerId)
        {
            if (customerId <= 0)
            {
                throw new ArgumentException("Invalid customerId. CustomerId must be greater than 0.");
            }
            IEnumerable<Product> purchasedProducts = await _purchasedProductRepository.GetPurchasedProductsByCustomerIdAsync(customerId);
            if (purchasedProducts == null || purchasedProducts.Count() == 0)
            {
                throw new NotFiniteNumberException("No purchased products were found");
            }
            IEnumerable<PurchasedProductDto> purchasedProductDtos = purchasedProducts.Select(p => new PurchasedProductDto
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                ProductPrice = p.ProductPrice,
                PurchasedQty = p.PurchasedQty
            }).ToList();
            return purchasedProductDtos;
        }
    }
}
