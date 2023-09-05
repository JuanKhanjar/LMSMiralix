using LMS.BusinessCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BusinessUseCases.PluginsInterfaces
{
    public interface IGroupProductRepository
    {
        Task<IEnumerable<GroupProduct>> GetGroupProductsByGroupId(int groupId);
    }
}
