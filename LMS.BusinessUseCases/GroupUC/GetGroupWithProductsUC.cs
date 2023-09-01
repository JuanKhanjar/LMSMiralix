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
    public class GetGroupWithProductsUC : IGetGroupWithProductsUC
    {
        private readonly IGroupRepository _groupRepository;

        public GetGroupWithProductsUC(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public async Task<Group> ExecuteAsync(int customerId, int groupId)
        {
            return await _groupRepository.GetGroupWithProductsAsync(customerId, groupId);
        }
    }
}
