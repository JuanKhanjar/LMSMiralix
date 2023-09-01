using LMS.BusinessCore.Entities;
using LMS.BusinessUseCases.GroupUC.GroupUCInterfaces;
using LMS.BusinessUseCases.PluginsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BusinessUseCases.GroupUC
{
    public class CreateGroupUC : ICreateGroupUC
    {
        private readonly IGroupRepository _groupRepository;

        public CreateGroupUC(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public async Task<Group> ExecuteAsyn(int customerId, string groupName)
        {
            return await _groupRepository.CreateGroupAsync(customerId, groupName);
        }
    }
}
