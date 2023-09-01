using LMS.BusinessCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BusinessUseCases.PluginsInterfaces
{
    public interface IGroupRepository
    {
        Task<Group> CreateGroupAsync(int customerId, string groupName);
        Task<List<Group>> GetGroupsForCustomerAsync(int customerId);
        Task<Group> GetGroupWithProductsAsync(int customerId, int groupId);
    }
}
