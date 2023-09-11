using LMS.BusinessCore.Entities;

namespace LMS.BusinessUseCases.GroupUCs.GroupUCInterfaces
{
    public interface ICreateGroupUC
    {
        Task<Group?> ExcecuteAsync(int customerId, string groupName);
    }
}