using LMS.BusinessCore.ViewModels;

namespace LMS.BusinessUseCases.GroupUCs.GroupUCInterfaces
{
    public interface IAddPurchasedQtysToGroupProductsUC
    {
        Task<bool> ExecuteAsync(int groupId, List<UpdateQuantityVM> purchasedQtys);
    }
}