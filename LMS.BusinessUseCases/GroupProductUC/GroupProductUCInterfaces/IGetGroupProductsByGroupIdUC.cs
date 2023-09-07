using LMS.BusinessCore.Entities;


namespace LMS.BusinessUseCases.GroupProductUC.GroupProductUCInterfaces
{
    public interface IGetGroupProductsByGroupIdUC
    {
        Task<IEnumerable<GroupProduct>> ExecuteAsync(int groupId);
    }
}