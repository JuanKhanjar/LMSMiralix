using LMS.BusinessCore.Entities;

namespace LMS.BusinessUseCases.PluginInterfaces
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetCustomerWithGroupsAndProductsAsync(int customerId);
    }
}
