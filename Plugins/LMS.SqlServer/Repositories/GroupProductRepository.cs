using LMS.BusinessCore.Entities;
using LMS.BusinessUseCases.PluginsInterfaces;
using LMS.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LMS.SqlServer.Repositories
{
    public class GroupProductRepository : IGroupProductRepository
    {
        private readonly IDbContextFactory<LMSDbContext> _dbContextFactory;
        private readonly ILogger<GroupProductRepository> _logger;

        public GroupProductRepository(IDbContextFactory<LMSDbContext> dbContextFactory, ILogger<GroupProductRepository> logger)
        {
            _dbContextFactory = dbContextFactory;
            _logger = logger;
        }
        /// <summary>
        /// To Get A list of Products for a spesific Group
        /// </summary>
        /// <param name="groupId">int</param>
        /// <returns>List<GroupProduct></returns>
        public async Task<IEnumerable<GroupProduct>> GetGroupProductsByGroupId(int groupId)
        {
            try
            {
                using LMSDbContext _dbContext = _dbContextFactory.CreateDbContext();
                var groupProducts = await _dbContext.GroupProducts
                    .Include(gp => gp.Group)
                    .Include(gp => gp.Product)
                    .Where(gp => gp.GroupId == groupId && gp.AddedQuantity > 0)
                    .ToListAsync();

                return groupProducts;
            }
            catch (Exception ex)
            {
                // Log the exception using ILogger.
                _logger.LogError(ex, "An error occurred while fetching group products.");

                // Return an empty list.
                return new List<GroupProduct>();
            }
        }
    }
}
