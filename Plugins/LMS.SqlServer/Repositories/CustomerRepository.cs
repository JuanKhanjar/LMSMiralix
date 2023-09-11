using LMS.BusinessCore.Entities;
using LMS.BusinessUseCases.PluginInterfaces;
using LMS.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.SqlServer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbContextFactory<LMSDbContext> _dbContextFactory;

        public CustomerRepository(IDbContextFactory<LMSDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Customer?> GetCustomerWithGroupsAndProductsAsync(int customerId)
        {
            using LMSDbContext _dbContext = _dbContextFactory.CreateDbContext();
            return await _dbContext.Customers
                .Include(c => c.Groups)
                    .ThenInclude(g => g.GroupProducts)
                        .ThenInclude(gp => gp.PurchasedProduct)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }
    }
}
