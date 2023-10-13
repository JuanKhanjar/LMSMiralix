using LMS.BusinessCore.Entities;
using LMS.BusinessUseCases.CustomerUCs.CustomerUCInterfaces;
using LMS.BusinessUseCases.Exceptions;
using LMS.BusinessUseCases.PluginInterfaces;
using Microsoft.Extensions.Logging;

namespace LMS.BusinessUseCases.CustomerUCs
{
    public class GetCustomerWithGroupsAndProductsUC : IGetCustomerWithGroupsAndProductsUC
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<GetCustomerWithGroupsAndProductsUC> _logger; 

        public GetCustomerWithGroupsAndProductsUC(ICustomerRepository customerRepository, ILogger<GetCustomerWithGroupsAndProductsUC> logger)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); 
        }

        public async Task<Customer?> ExecuteAsync(int customerId)
        {
            if (customerId <= 0)
            {
                _logger.LogError("Invalid customerId: {CustomerId}", customerId);
                throw new InvalidCustomerIdException("customerId must be a positive integer.");
            }

            try
            {
                Customer? customer = await _customerRepository.GetCustomerWithGroupsAndProductsAsync(customerId);

                if (customer == null)
                {
                    _logger.LogWarning("Customer with ID {CustomerId} not found.", customerId);
                    throw new CustomerNotFoundException($"Customer with ID {customerId} not found.");
                }

                return customer; // The return type is Customer?, indicating that the method can return null.
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching customer data for CustomerId: {CustomerId}", customerId);
                throw; // Re-throw the exception for proper error handling higher up the call stack.
            }
        }
    }
}



