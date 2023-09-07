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
        /// <summary>
        /// Get A list of customer Purchased Products
        /// </summary>
        /// <param name="customerId">int</param>
        /// <returns>A list<PurchasedProduct></returns>
        public async Task<IEnumerable<PurchasedProduct>> GetPurchasedProductsByCustomerIdAsync(int customerId)
        {
            using LMSDbContext _dbContext = _dbContextFactory.CreateDbContext();

            var purchasedProducts = await _dbContext.PurchasedProducts
                .Where(p => p.CustomerId == customerId && p.PurchasedQty > 0)
                .OrderBy(p=>p.PurchasedQty)
                .ToListAsync();
            return purchasedProducts;
        }
    }
}
