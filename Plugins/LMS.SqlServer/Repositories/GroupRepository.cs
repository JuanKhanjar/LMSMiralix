using LMS.BusinessUseCases.PluginsInterfaces;
using LMS.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using Group = LMS.BusinessCore.Entities.Group;

namespace LMS.SqlServer.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly IDbContextFactory<LMSDbContext> _dbContextFactory;

        public GroupRepository(IDbContextFactory<LMSDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Group> CreateGroupAsync(int customerId, string groupName)
        {
            using LMSDbContext _dbContext = _dbContextFactory.CreateDbContext();
            var customer = await _dbContext.Customers.FindAsync(customerId) ?? throw new ArgumentException("Customer not found.");

            // Generate a random 3-digit number from 111 to 999
            var random = new Random();
            var eanNumber = random.Next(111, 1000);

            // Get the current year and take the last two digits
            var currentYear = DateTime.Now.Year % 100;

            // Create the EAN using the specified format
            var ean = $"{customer.CustomerName[0]}{customer.CustomerName[^1]}{eanNumber:D3}{currentYear:D2}";

            var newGroup = new Group
            {
                GroupName = groupName,
                CustomerId = customerId,
                Customer = customer,
                EAN = ean
            };

            _dbContext.Groups.Add(newGroup);
            await _dbContext.SaveChangesAsync();

            return newGroup;
        }


        /// <summary>
        /// Get A list<Group> 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>A list of customer's Groups including all Group's Products</returns>
        public async Task<List<Group>> GetGroupsForCustomerAsync(int customerId)
        {
            using LMSDbContext _dbContext = _dbContextFactory.CreateDbContext();
            return await _dbContext.Groups
                .Where(g => g.CustomerId == customerId)
                .Include(g => g.GroupProducts)
                .ThenInclude(gp=>gp.Product)
                .ToListAsync();
        }

        /// <summary>
        /// Get a Spesific Group Including All its Group Products 
        /// </summary>
        /// <param name="customerId">int</param>
        /// <param name="groupId">int</param>
        /// <returns>Group</returns>
        public async Task<Group?> CreateGroupDetailsIncludingItsProductsAsync(int customerId, int groupId)
        {
            using LMSDbContext _dbContext = _dbContextFactory.CreateDbContext();
            return await _dbContext.Groups
            .Include(g => g.GroupProducts)
            .ThenInclude(gp=>gp.Product)
            .FirstOrDefaultAsync(g => g.CustomerId == customerId && g.GroupId == groupId);
        }
    }
}
