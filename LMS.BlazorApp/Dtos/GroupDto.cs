namespace LMS.BlazorApp.Dtos
{
    public class GroupDto
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string EAN { get; set; }
        public int CustomerId { get; set; }
        public List<GroupProductDto> GroupProductsDto { get; set; } = new List<GroupProductDto>();

        public GroupDto()
        {
            GroupProductsDto = new List<GroupProductDto>();
        }
    }
}
