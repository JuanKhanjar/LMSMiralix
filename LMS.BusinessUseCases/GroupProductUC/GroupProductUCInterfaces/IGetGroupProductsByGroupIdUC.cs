using LMS.BusinessUseCases.Dtos.GroupProducts;

namespace LMS.BusinessUseCases.GroupProductUC.GroupProductUCInterfaces
{
    public interface IGetGroupProductsByGroupIdUC
    {
        Task<IEnumerable<GroupProductDto>> ExecuteAsync(int groupId);
    }
}