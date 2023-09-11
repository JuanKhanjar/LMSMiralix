using LMS.BusinessCore.Entities;

namespace LMS.BusinessUseCases.CustomerUCs.CustomerUCInterfaces
{
    public interface IGetCustomerWithGroupsAndProductsUC
    {
        Task<Customer?> ExecuteAsync(int customerId);
    }
}