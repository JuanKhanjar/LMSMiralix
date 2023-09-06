using LMS.BusinessCore.Entities;
using LMS.BusinessUseCases.Dtos.PurchaseProducts;

namespace LMS.BusinessUseCases.PurchasedProductsUC.PurchasedProductUCInterfaces
{
    public interface IGetPurchasedProductsByCustomerIdUC
    {
        Task<IEnumerable<Product>> ExecuteAsync(int customerId);
    }
}