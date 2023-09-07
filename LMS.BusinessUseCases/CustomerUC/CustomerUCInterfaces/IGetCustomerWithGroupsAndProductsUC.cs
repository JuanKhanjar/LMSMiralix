using LMS.BusinessCore.Entities;

namespace LMS.BusinessUseCases.CustomerUC.CustomerUCInterfaces
{
    public interface IGetCustomerWithGroupsAndProductsUC
    {
        Task<Customer?> ExecuteAsync(int customerId);
    }
}