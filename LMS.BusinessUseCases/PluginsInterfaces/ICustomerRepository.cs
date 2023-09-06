using LMS.BusinessCore.Entities;

namespace LMS.BusinessUseCases.PluginsInterfaces
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetCustomerWithGroupsAndProductsAsync(int customerId);
    }
}
