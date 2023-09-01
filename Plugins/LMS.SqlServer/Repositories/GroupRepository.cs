using LMS.BusinessCore.Entities;
using LMS.BusinessUseCases.PluginsInterfaces;
using LMS.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
            var newGroup = new Group
            {
                GroupName = groupName,
                CustomerId = customerId,
                Customer = customer
            };

            var groupNameInitial = groupName.First().ToString().ToUpper();
            var groupCount = _dbContext.Groups.Count(g => g.CustomerId == customerId) + 1;
            var eanNumber = new Random().Next(111, 1000); // Generate a random 3-digit number from 111 to 999
            var lastCustomerInitial = customer.CustomerName.First();

            var ean = $"{groupNameInitial}{eanNumber:D3}{lastCustomerInitial}";

            newGroup.EAN = ean;

            _dbContext.Groups.Add(newGroup);
            await _dbContext.SaveChangesAsync();

            return newGroup;
        }

        public async Task<List<Group>> GetGroupsForCustomerAsync(int customerId)
        {
            using LMSDbContext _dbContext = _dbContextFactory.CreateDbContext();
            return await _dbContext.Groups
             .Where(g => g.CustomerId == customerId)
             .ToListAsync();
        }

        public async Task<Group> GetGroupWithProductsAsync(int customerId, int groupId)
        {
            using LMSDbContext _dbContext = _dbContextFactory.CreateDbContext();
            return await _dbContext.Groups
            .Include(g => g.GroupProducts)
            .FirstOrDefaultAsync(g => g.CustomerId == customerId && g.GroupId == groupId);
        }
    }
}
