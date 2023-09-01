using LMS.BusinessCore.Entities;

namespace LMS.BusinessUseCases.GroupUC.GroupUCInterfaces
{
    public interface IGetGroupsForCustomerUC
    {
        Task<List<Group>> ExecuteAsync(int customerId);
    }
}