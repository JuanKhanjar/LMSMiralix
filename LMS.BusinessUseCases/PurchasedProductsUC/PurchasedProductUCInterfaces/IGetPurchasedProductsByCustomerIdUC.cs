using LMS.BusinessUseCases.Dtos.PurchaseProducts;

namespace LMS.BusinessUseCases.PurchasedProductsUC.PurchasedProductUCInterfaces
{
    public interface IGetPurchasedProductsByCustomerIdUC
    {
        Task<IEnumerable<PurchasedProductDto>> ExecuteAsync(int customerId);
    }
}