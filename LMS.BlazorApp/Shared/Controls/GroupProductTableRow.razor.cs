using LMS.BlazorApp.Dtos;
using LMS.BusinessCore.Entities;
using Microsoft.AspNetCore.Components;

namespace LMS.BlazorApp.Shared.Controls
{
    public partial class GroupProductTableRow
    {

        [Parameter]
        public GroupProductDto GroupProduct { get; set; } = new GroupProductDto();

        [Parameter]
        public int PurchasedProduct { get; set; }
        [Parameter]
        public EventCallback<GroupProductDto> RemoveProduct { get; set; }

    }
}
