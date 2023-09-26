using LMS.BlazorApp.Dtos;
using Microsoft.AspNetCore.Components;

namespace LMS.BlazorApp.Shared.Controls
{
    public partial class GroupProductTableRow
    {

        [Parameter]
        public GroupProductDto GroupProduct { get; set; } = new GroupProductDto();

        [Parameter]
        public int PurchasedProductAvailability { get; set; }

        [Parameter]
        public EventCallback<GroupProductDto> RemoveProduct { get; set; }

        private bool IsInvalidQuantity()
        {
            return (PurchasedProductAvailability - GroupProduct.InputProductQuantity) == 0 || (GroupProduct.AddedQty * -1 == GroupProduct.InputProductQuantity);
        }

        private async Task RemoveProductClicked()
        {
            await RemoveProduct.InvokeAsync(GroupProduct);
        }
        [Parameter]
        public EventCallback<int> PurchasedProductAvailabilityQuantityChanged { get; set; }

        private void HandleInputProductQuantityChanged()
        {
            // Notify the parent component of the input value change
            PurchasedProductAvailabilityQuantityChanged.InvokeAsync(PurchasedProductAvailability);
        }
    }
}
