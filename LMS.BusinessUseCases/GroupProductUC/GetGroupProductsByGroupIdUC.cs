using LMS.BusinessCore.Entities;
using LMS.BusinessUseCases.GroupProductUC.GroupProductUCInterfaces;
using LMS.BusinessUseCases.PluginsInterfaces;

namespace LMS.BusinessUseCases.GroupProductUC
{
    public class GetGroupProductsByGroupIdUC : IGetGroupProductsByGroupIdUC
    {
        private readonly IGroupProductRepository _groupProductRepository;

        public GetGroupProductsByGroupIdUC(IGroupProductRepository groupProductRepository)
        {
            _groupProductRepository = groupProductRepository;
        }
        public async Task<IEnumerable<GroupProduct>> ExecuteAsync(int groupId)
        {
            if (groupId <= 0)
            {
                throw new ArgumentException("Invalid groupId. GroupId must be greater than 0.");
            }
            IEnumerable<GroupProduct> groupedProducts = await _groupProductRepository.GetGroupProductsByGroupId(groupId);
            if (groupedProducts == null || groupedProducts.Count() == 0)
            {
                throw new NotFiniteNumberException("No products were found");
            }
            
            return groupedProducts;
        }
    }
}
