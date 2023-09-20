namespace LMS.BusinessUseCases.GroupUCs.GroupUCInterfaces
{
    public interface IDeleteGroupWithProductsUC
    {
        Task<bool> ExecuteAsync(int groupId);
    }
}