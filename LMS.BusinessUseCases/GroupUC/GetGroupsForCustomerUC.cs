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
    public class GetGroupsForCustomerUC : IGetGroupsForCustomerUC
    {
        private readonly IGroupRepository _groupRepository;

        public GetGroupsForCustomerUC(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public async Task<List<Group>> ExecuteAsync(int customerId)
        {
            return await _groupRepository.GetGroupsForCustomerAsync(customerId);
        }
    }
}
