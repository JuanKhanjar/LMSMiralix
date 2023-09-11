using LMS.BusinessCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BusinessUseCases.PluginInterfaces
{
    public interface IGroupRepository
    {
        Task<Group?> GetGroupWithProductsByGroupIdAsync(int customerId, int groupId);
        Task<Group?> CreateGroupAsync(int customerId, string groupName);
        Task<bool> UpdateGroupNameAsync(int groupId, string newGroupName);
        Task<bool> DeleteGroupWithProductsAsync(int groupId);
        Task<bool> DeleteGroupProductAsync(int groupId, int groupProductId);
        Task<bool> AddPurchasedQtysToGroupProductsAsync(int groupId, List<Tuple<int, int>> purchasedQtys);
    }
}
