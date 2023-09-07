using LMS.BusinessCore.Entities;

namespace LMS.BusinessUseCases.PluginsInterfaces
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetCustomerByIdAsync(int customerId);
        Task<Customer?> GetCustomerWithGroupsAndProductsAsync(int customerId);
        Task<Customer?> GetCustomerByIdAsync(string customerEamil);
    }
}
