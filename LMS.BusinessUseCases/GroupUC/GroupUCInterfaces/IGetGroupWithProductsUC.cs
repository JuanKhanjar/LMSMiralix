using LMS.BusinessCore.Entities;

namespace LMS.BusinessUseCases.GroupUC.GroupUCInterfaces
{
    public interface IGetGroupWithProductsUC
    {
        Task<Group?> ExecuteAsync(int customerId, int groupId);
    }
}