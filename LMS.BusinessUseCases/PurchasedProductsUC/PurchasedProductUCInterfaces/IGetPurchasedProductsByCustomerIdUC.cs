using LMS.BusinessCore.Entities;

namespace LMS.BusinessUseCases.PurchasedProductsUC.PurchasedProductUCInterfaces
{
    public interface IGetPurchasedProductsByCustomerIdUC
    {
        Task<IEnumerable<PurchasedProduct>> ExecuteAsync(int customerId);
    }
}