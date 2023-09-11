using LMS.BusinessCore.Entities;

namespace LMS.BusinessUseCases.PurchasedProductsUCs.PurchasedProductsUCsInterfaces
{
    public interface IGetPurchasedProductsByCustomerIdUC
    {
        Task<IEnumerable<PurchasedProduct>> ExecuteAsync(int customerId);
    }
}