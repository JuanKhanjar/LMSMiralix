using LMS.BusinessCore.Entities;
using LMS.BusinessUseCases.PluginsInterfaces;
using LMS.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS.SqlServer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbContextFactory<LMSDbContext> _dbContextFactory;

        public CustomerRepository(IDbContextFactory<LMSDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public Task<Customer?> GetCustomerByIdAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<Customer?> GetCustomerByIdAsync(string customerEamil)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer?> GetCustomerWithGroupsAndProductsAsync(int customerId)
        {
            using LMSDbContext _dbContext = _dbContextFactory.CreateDbContext();
            return await _dbContext.Customers
            .Include(c => c.Groups)
                .ThenInclude(g => g.GroupProducts)
                    .ThenInclude(gp => gp.Product)
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }
    }
}
