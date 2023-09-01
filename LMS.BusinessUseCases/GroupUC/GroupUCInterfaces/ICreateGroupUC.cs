using LMS.BusinessCore.Entities;

namespace LMS.BusinessUseCases.GroupUC.GroupUCInterfaces
{
    public interface ICreateGroupUC
    {
        Task<Group> ExecuteAsyn(int customerId, string groupName);
    }
}