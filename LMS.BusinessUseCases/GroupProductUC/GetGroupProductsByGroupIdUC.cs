using LMS.BusinessCore.Entities;
using LMS.BusinessUseCases.Dtos.GroupProducts;
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
        public async Task<IEnumerable<GroupProductDto>> ExecuteAsync(int groupId)
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
            IEnumerable<GroupProductDto> groupedProductDtos = groupedProducts.Select(gp => new GroupProductDto
            {
                GroupProductId = gp.GroupProductId,
                GroupId = gp.GroupId,
                GroupName = gp.Group.GroupName,
                ProdcutName=gp.Product.ProductName,
                ProductId = gp.ProductId,
                AddedQuantity = gp.AddedQuantity,
                Price=gp.Product.ProductPrice,
                Subtotal= gp.AddedQuantity* gp.Product.ProductPrice
            })
            .ToList();
            return groupedProductDtos;
        }
    }
}
