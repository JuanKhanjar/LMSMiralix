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
        /// <summary>
        /// Get A List<Group> for a spesific Customer
        /// </summary>
        /// <param name="customerId">int</param>
        ///  /// <param name="groupName">string</param>
        /// <returns>A list of type Group for Sepesicif Customer </returns>
        Task<List<Group>> GetGroupsForCustomerAsync(int customerId);

        /// <summary>
        /// Get a Spesific Group By Its Id And CustomerId
        /// </summary>
        /// <param name="customerId">Int</param>
        /// <param name="groupId">Int</param>
        /// <returns>An object of type Group including all its Group_Prodcts</returns>
        Task<Group?> CreateGroupDetailsIncludingItsProductsAsync(int customerId, int groupId);
    }
}
