using LMS.BusinessCore.ViewModels;
using LMS.BusinessUseCases.Exceptions;
using LMS.BusinessUseCases.GroupUCs.GroupUCInterfaces;
using LMS.BusinessUseCases.PluginInterfaces;
using Microsoft.Extensions.Logging;

namespace LMS.BusinessUseCases.GroupUCs
{
    public class AddPurchasedQtysToGroupProductsUC : IAddPurchasedQtysToGroupProductsUC
    {
        private readonly IGroupRepository _groupRepository;
        private readonly ILogger<AddPurchasedQtysToGroupProductsUC> _logger; // Inject ILogger

        public AddPurchasedQtysToGroupProductsUC(IGroupRepository groupRepository, ILogger<AddPurchasedQtysToGroupProductsUC> logger)
        {
            _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); // Validate that logger is not null
        }
        public async Task<bool> ExecuteAsync(int groupId, List<UpdateQuantityVM> purchasedQtys)
        {
            if (groupId <= 0)
            {
                _logger.LogError("Invalid groupId: {groupId}", groupId);
                throw new InvalidCustomerIdException("groupId must be a positive integer.");
            }
            try
            {
                // Validate that _groupRepository is properly injected and used to create the group.

                // Call the repository to create the group
                var updateQuantities = await _groupRepository.AddPurchasedQtysToGroupProductsAsync(groupId, purchasedQtys);

                if (!updateQuantities)
                {
                    _logger.LogError("Failed to update quantities. GroupId: {GroupId}", groupId);
                    return false; // Return false to indicate failure.
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to update quantities for a group: {groupId}", groupId);
                throw; // Re-throw the exception for proper error handling higher up the call stack.
            }
        }
    }
}
