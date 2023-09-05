using LMS.BusinessCore.Entities;
using LMS.BusinessUseCases.PluginsInterfaces;
using LMS.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS.SqlServer.Repositories
{
    public class PurchasedProductRepository : IPurchasedProductRepository
    {
        private readonly IDbContextFactory<LMSDbContext> _dbContextFactory;

        public PurchasedProductRepository(IDbContextFactory<LMSDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<Product>> GetPurchasedProductsByCustomerIdAsync(int customerId)
        {
            using LMSDbContext _dbContext = _dbContextFactory.CreateDbContext();

            var purchasedProducts = await _dbContext.Products
                .Where(p => p.CustomerId == customerId && p.PurchasedQty > 0)
                .ToListAsync();
            return purchasedProducts;
        }
    }
}
