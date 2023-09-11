using LMS.BusinessCore.Entities;
using LMS.BusinessUseCases.Exceptions;
using LMS.BusinessUseCases.GroupUCs.GroupUCInterfaces;
using LMS.BusinessUseCases.PluginInterfaces;
using Microsoft.Extensions.Logging;

namespace LMS.BusinessUseCases.GroupUCs
{
    public class CreateGroupUC : ICreateGroupUC
    {
        private readonly IGroupRepository _groupRepository;
        private readonly ILogger<CreateGroupUC> _logger; // Inject ILogger

        public CreateGroupUC(IGroupRepository groupRepository, ILogger<CreateGroupUC> logger)
        {
            _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); // Validate that logger is not null
        }
        public async Task<Group?> ExcecuteAsync(int customerId, string groupName)
        {
            if (customerId <= 0)
            {
                _logger.LogError("Invalid customerId: {CustomerId}", customerId);
                throw new InvalidCustomerIdException("customerId must be a positive integer.");
            }

            try
            {
                // Validate that _groupRepository is properly injected and used to create the group.

                // Call the repository to create the group
                var createdGroup = await _groupRepository.CreateGroupAsync(customerId, groupName);

                if (createdGroup == null)
                {
                    _logger.LogError("Failed to create a new group.");
                    throw new GroupCreationException("Failed to create a new group.");
                }

                return createdGroup;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a group for CustomerId: {CustomerId}", customerId);
                throw; // Re-throw the exception for proper error handling higher up the call stack.
            }
        }
    }
}
