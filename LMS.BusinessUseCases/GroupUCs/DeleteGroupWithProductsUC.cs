using LMS.BusinessUseCases.Exceptions;
using LMS.BusinessUseCases.GroupUCs.GroupUCInterfaces;
using LMS.BusinessUseCases.PluginInterfaces;
using Microsoft.Extensions.Logging;

namespace LMS.BusinessUseCases.GroupUCs
{
    public class DeleteGroupWithProductsUC : IDeleteGroupWithProductsUC
    {
        private readonly IGroupRepository _groupRepository;
        private readonly ILogger<DeleteGroupWithProductsUC> _logger;

        public DeleteGroupWithProductsUC(IGroupRepository groupRepository, ILogger<DeleteGroupWithProductsUC> logger)
        {
            _groupRepository = groupRepository;
            _logger = logger;
        }
        public async Task<bool> ExecuteAsync(int groupId)
        {
            if (groupId <= 0)
            {
                _logger.LogError("Invalid group Id: {GroupId}", groupId);
                throw new ArgumentOutOfRangeException(nameof(groupId), "groupId must be a positive integer.");
            }

            try
            {
                // Attempt to delete the group and its products.
                bool result = await _groupRepository.DeleteGroupWithProductsAsync(groupId);

                if (!result)
                {
                    _logger.LogError("Failed to delete a group with its products. GroupId: {GroupId}", groupId);
                    return false; // Return false to indicate failure.
                }

                return true; // Return true to indicate success.
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while removing a group for GroupId: {GroupId}", groupId);
                throw; // Re-throw the exception for proper error handling higher up the call stack.
            }
        }
    }
}
