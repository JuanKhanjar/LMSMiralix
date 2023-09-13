using LMS.BusinessUseCases.GroupUCs.GroupUCInterfaces;
using LMS.BusinessUseCases.PluginInterfaces;
using Microsoft.Extensions.Logging;

namespace LMS.BusinessUseCases.GroupUCs
{
    public class UpdateGroupNameUC : IUpdateGroupNameUC
    {
        private readonly IGroupRepository _groupRepository;
        private readonly ILogger<UpdateGroupNameUC> _logger;
        public UpdateGroupNameUC(IGroupRepository groupRepository, ILogger<UpdateGroupNameUC> logger)
        {
            _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<bool> ExcecuteAsync(int groupId, string newGroupName)
        {
            return await _groupRepository.UpdateGroupNameAsync(groupId, newGroupName);
        }
    }
}
