using LMS.BusinessCore.Entities;
using LMS.BusinessUseCases.CustomerUC.CustomerUCInterfaces;
using LMS.BusinessUseCases.PluginsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BusinessUseCases.CustomerUC
{
    public class GetCustomerWithGroupsAndProductsUC : IGetCustomerWithGroupsAndProductsUC
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerWithGroupsAndProductsUC(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Customer?> ExecuteAsync(int customerId)
        {
            // Validate input
            if (customerId <= 0)
            {
                throw new ArgumentException("Invalid customerId. CustomerId must be greater than 0.");
            }

            try
            {
                return await _customerRepository.GetCustomerWithGroupsAndProductsAsync(customerId);
            }
            catch (Exception ex)
            {
                // Handle any database-related exceptions here, e.g., log the error or rethrow
                throw new InvalidOperationException("An error occurred while retrieving the customer.", ex);
            }
        }
    }
}
