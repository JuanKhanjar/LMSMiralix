using LMS.BusinessCore.Entities;
using LMS.BusinessUseCases.PluginsInterfaces;
using LMS.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS.SqlServer.Repositories
{
    public class GroupProductRepository : IGroupProductRepository
    {
        private readonly IDbContextFactory<LMSDbContext> _dbContextFactory;

        public GroupProductRepository(IDbContextFactory<LMSDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<GroupProduct>> GetGroupProductsByGroupId(int groupId)
        {
            using LMSDbContext _dbContext = _dbContextFactory.CreateDbContext();
            var groupProducts = await _dbContext.GroupProducts
                .Include(g=>g.Group)
                .Include(p=>p.Product)
            .Where(gp => gp.GroupId == groupId && gp.AddedQuantity>0)
            .ToListAsync();
            return groupProducts;
        }
    }
}
