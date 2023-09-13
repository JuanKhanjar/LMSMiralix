namespace LMS.BusinessUseCases.GroupUCs.GroupUCInterfaces
{
    public interface IUpdateGroupNameUC
    {
        Task<bool> ExcecuteAsync(int groupId, string newGroupName);
    }
}