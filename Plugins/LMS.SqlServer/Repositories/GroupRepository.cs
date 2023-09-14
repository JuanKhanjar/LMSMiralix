using LMS.BusinessCore.Entities;
using LMS.BusinessUseCases.PluginInterfaces;
using LMS.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace LMS.SqlServer.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly IDbContextFactory<LMSDbContext> _dbContextFactory;
        private readonly ILogger<GroupRepository> _logger;

        public GroupRepository(IDbContextFactory<LMSDbContext> dbContextFactory, ILogger<GroupRepository> logger)
        {
            _dbContextFactory = dbContextFactory;
            _logger = logger;
        }

        public async Task<bool> AddPurchasedQtysToGroupProductsAsync(int groupId, List<Tuple<int, int>> purchasedQtys)
        {
            if (groupId <= 0 || purchasedQtys == null || !purchasedQtys.Any())
            {
                _logger.LogError("Invalid input parameters for AddPurchasedQtysToGroupProductsAsync: groupId={GroupId}, purchasedQtys={PurchasedQtys}", groupId, purchasedQtys);
                throw new ArgumentException("Invalid input parameters.", nameof(groupId));
            }

            using (LMSDbContext _dbContext = _dbContextFactory.CreateDbContext())
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var (purchasedProductId, qty) in purchasedQtys)
                        {
                            // Find the specific GroupProduct and the associated PurchasedProduct
                            GroupProduct? groupProduct = await _dbContext.GroupProducts
                                .Include(gp => gp.PurchasedProduct)
                                .FirstOrDefaultAsync(gp => gp.GroupId == groupId && gp.PurchasedProductId == purchasedProductId);

                            if (groupProduct == null)
                            {
                                // Log a warning if the GroupProduct is not found
                                _logger.LogWarning("GroupProduct not found for groupId: {GroupId} and purchasedProductId: {PurchasedProductId}", groupId, purchasedProductId);
                                return false; // Return false if the GroupProduct is not found
                            }

                            // Find the corresponding PurchasedProduct
                            PurchasedProduct? purchasedProduct = groupProduct.PurchasedProduct;

                            if (purchasedProduct == null || purchasedProduct.PurchasedQty < qty)
                            {
                                // Log a warning if the PurchasedProduct is not found or if the PurchasedQty is insufficient
                                _logger.LogWarning("PurchasedProduct not found or insufficient quantity for purchasedProductId: {PurchasedProductId}", purchasedProductId);
                                return false; // Return false if the PurchasedProduct is not found or insufficient quantity
                            }

                            // Update the GroupProduct's AddedQuantity
                            groupProduct.AddedQuantity += qty;

                            // Update the PurchasedProduct's PurchasedQty
                            purchasedProduct.PurchasedQty -= qty;
                        }

                        // Save changes to apply the updates
                        await _dbContext.SaveChangesAsync();

                        // Commit the transaction
                        transaction.Commit();

                        return true; // Return true to indicate a successful update
                    }
                    catch (Exception ex)
                    {
                        // Log an error and roll back the transaction if an exception occurs
                        _logger.LogError(ex, "Error occurred while adding PurchasedQtys to GroupProducts (groupId: {GroupId})", groupId);
                        transaction.Rollback();
                        throw; // Rethrow the exception for handling at a higher level
                    }
                }
            }
        }
        public async Task<Group?> GetGroupWithProductsByGroupIdAsync(int customerId, int groupId)
        {
            if (groupId <= 0)
            {
                _logger.LogError("Invalid groupId provided: {GroupId}", groupId);
                throw new ArgumentException("Invalid groupId provided.", nameof(groupId));
            }

            using (LMSDbContext _dbContext = _dbContextFactory.CreateDbContext())
            {
                var group = await _dbContext.Groups
                    .Include(g => g.GroupProducts)
                        .ThenInclude(gp => gp.PurchasedProduct)
                    .FirstOrDefaultAsync(g => g.CustomerId == customerId && g.GroupId == groupId);

                if (group == null)
                {
                    _logger.LogWarning("Group not found for groupId: {GroupId}", groupId);
                }

                return group;
            }
        }

        public async Task<Group?> CreateGroupAsync(int customerId, string groupName)
        {
            if (string.IsNullOrWhiteSpace(groupName))
            {
                _logger.LogError("Invalid group name provided.");
                throw new ArgumentException("Group name is required.", nameof(groupName));
            }

            using (LMSDbContext _dbContext = _dbContextFactory.CreateDbContext())
            {
                // Check if a group with the same name already exists for the customer
                bool groupExists = await _dbContext.Groups
                    .AnyAsync(g => g.CustomerId == customerId && g.GroupName == groupName);

                if (groupExists)
                {
                    _logger.LogError("Group with the same name already exists for customer.");
                    throw new InvalidOperationException("A group with the same name already exists for this customer.");
                }
                // Generate EAN as per the specified format
                string ean = GenerateEAN(groupName);

                // Create a new group
                var group = new Group
                {
                    GroupName = groupName,
                    EAN = ean,
                    CustomerId = customerId
                };

                // Add the group to the database
                _dbContext.Groups.Add(group);
                await _dbContext.SaveChangesAsync();

                return group;
            }
        }

        public async Task<bool> UpdateGroupNameAsync(int groupId, string newGroupName)
        {
            if (string.IsNullOrWhiteSpace(newGroupName))
            {
                _logger.LogError("Invalid group name provided.");
                throw new ArgumentException("Group name is required.", nameof(newGroupName));
            }

            using (LMSDbContext _dbContext = _dbContextFactory.CreateDbContext())
            {
                Group? groupToUpdate = await _dbContext.Groups.FindAsync(groupId);

                if (groupToUpdate == null)
                {
                    _logger.LogWarning("Group not found for groupId: {GroupId}", groupId);
                    return false; // Return false if the group is not found
                }

                // Update the group name
                groupToUpdate.GroupName = newGroupName;

                await _dbContext.SaveChangesAsync();

                return true; // Return true to indicate a successful update
            }
        }

        public async Task<bool> DeleteGroupProductAsync(int groupId, int groupProductId)
        {
            using (LMSDbContext _dbContext = _dbContextFactory.CreateDbContext())
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        // Find the group product to be deleted, including its associated Product
                        GroupProduct? groupProductToDelete = await _dbContext.GroupProducts
                            .Include(gp => gp.PurchasedProduct)
                            .FirstOrDefaultAsync(gp => gp.GroupProductId == groupProductId && gp.GroupId == groupId);

                        if (groupProductToDelete == null)
                        {
                            // Log a warning if the group product is not found
                            _logger.LogWarning("GroupProduct not found for groupId: {GroupId} and groupProductId: {GroupProductId}", groupId, groupProductId);
                            return false; // Return false if the group product is not found
                        }

                        // Add the AddedQuantity of the group product to the corresponding PurchasedProduct's PurchasedQty
                        PurchasedProduct? purchasedProduct = groupProductToDelete.PurchasedProduct;
                        purchasedProduct.PurchasedQty += groupProductToDelete.AddedQuantity;

                        // Remove the group product from the group
                        _dbContext.GroupProducts.Remove(groupProductToDelete);

                        // Save changes to apply the deletion and quantity update
                        await _dbContext.SaveChangesAsync();

                        // Commit the transaction
                        transaction.Commit();

                        return true; // Return true to indicate a successful deletion
                    }
                    catch (Exception ex)
                    {
                        // Log an error and roll back the transaction if an exception occurs
                        _logger.LogError(ex, "Error occurred while deleting GroupProduct and updating PurchasedProduct (groupId: {GroupId}, groupProductId: {GroupProductId})", groupId, groupProductId);
                        transaction.Rollback();
                        throw; // Rethrow the exception for handling at a higher level
                    }
                }
            }
        }

        public async Task<bool> DeleteGroupWithProductsAsync(int groupId)
        {
            using (LMSDbContext _dbContext = _dbContextFactory.CreateDbContext())
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        // Find the group to be deleted, including its associated GroupProducts
                        Group? groupToDelete = await _dbContext.Groups
                            .Include(g => g.GroupProducts)
                            .FirstOrDefaultAsync(g => g.GroupId == groupId);

                        if (groupToDelete == null)
                        {
                            // Log a warning if the group is not found
                            _logger.LogWarning("Group not found for groupId: {GroupId}", groupId);
                            return false; // Return false if the group is not found
                        }

                        // Iterate through the GroupProducts and add their AddedQuantity to corresponding PurchasedProduct
                        foreach (GroupProduct groupProduct in groupToDelete.GroupProducts)
                        {
                            PurchasedProduct? purchasedProduct = await _dbContext.PurchasedProducts
                                .FirstOrDefaultAsync(pp => pp.ProductId == groupProduct.PurchasedProductId);

                            if (purchasedProduct != null)
                            {
                                purchasedProduct.PurchasedQty += groupProduct.AddedQuantity;
                            }
                        }

                        // Remove all associated GroupProducts from the group
                        _dbContext.GroupProducts.RemoveRange(groupToDelete.GroupProducts);

                        // Remove the group itself
                        _dbContext.Groups.Remove(groupToDelete);

                        // Save changes to apply the deletion and quantity updates
                        await _dbContext.SaveChangesAsync();

                        // Commit the transaction
                        transaction.Commit();

                        return true; // Return true to indicate a successful deletion
                    }
                    catch (Exception ex)
                    {
                        // Log an error and roll back the transaction if an exception occurs
                        _logger.LogError(ex, "Error occurred while deleting Group with Products (groupId: {GroupId})", groupId);
                        transaction.Rollback();
                        throw; // Rethrow the exception for handling at a higher level
                    }
                }
            }
        }

        public async Task<bool> DeleteGroupProductsAsync(int groupId)
        {
            using (LMSDbContext _dbContext = _dbContextFactory.CreateDbContext())
            {
                using (IDbContextTransaction transaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        // Find the group to be updated, including its associated GroupProducts
                        Group? groupToUpdate = await _dbContext.Groups
                            .Include(g => g.GroupProducts)
                            .FirstOrDefaultAsync(g => g.GroupId == groupId);

                        if (groupToUpdate == null)
                        {
                            // Log a warning if the group is not found
                            _logger.LogWarning("Group not found for groupId: {GroupId}", groupId);
                            return false; // Return false if the group is not found
                        }

                        // Iterate through the GroupProducts and add their AddedQuantity to corresponding PurchasedProduct
                        foreach (GroupProduct groupProduct in groupToUpdate.GroupProducts)
                        {
                            PurchasedProduct? purchasedProduct = await _dbContext.PurchasedProducts
                                .FirstOrDefaultAsync(pp => pp.ProductId == groupProduct.PurchasedProductId);

                            if (purchasedProduct != null)
                            {
                                purchasedProduct.PurchasedQty += groupProduct.AddedQuantity;
                            }
                        }

                        // Remove all associated GroupProducts from the group
                        _dbContext.GroupProducts.RemoveRange(groupToUpdate.GroupProducts);

                        // Save changes to apply the deletion and quantity updates
                        await _dbContext.SaveChangesAsync();

                        // Commit the transaction
                        transaction.Commit();

                        return true; // Return true to indicate successful deletion of GroupProducts
                    }
                    catch (Exception ex)
                    {
                        // Log an error and roll back the transaction if an exception occurs
                        _logger.LogError(ex, "Error occurred while deleting GroupProducts (groupId: {GroupId})", groupId);
                        transaction.Rollback();
                        throw; // Rethrow the exception for handling at a higher level
                    }
                }
            }
        }

        // Helper method to generate EAN based on the specified format
        private string GenerateEAN(string groupName)
        {
            Random random = new Random();
            int randomDigits = random.Next(1000, 10000);
            string lastLetter = groupName.Substring(groupName.Length - 1).ToUpper();
            string year = DateTime.Now.Year.ToString().Substring(2);

            return $"{char.ToUpper(groupName[0])}{randomDigits}{lastLetter}-{year}";
        }
    }
}
