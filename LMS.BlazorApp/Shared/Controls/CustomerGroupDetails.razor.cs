using LMS.BusinessCore.Entities;
using Microsoft.AspNetCore.Components;

namespace LMS.BlazorApp.Shared.Controls
{
    public partial class CustomerGroupDetails
    {
        [Parameter]
        public Customer _customer { get; set; } = new Customer();

        [Parameter]
        public Group group { get; set; } = new Group();

        [Parameter]
        public EventCallback<int> ShowGroupDetails { get; set; }

        [Parameter]
        public EventCallback<int> DeleteGroupWithAllItsGP { get; set; }
    }
}
