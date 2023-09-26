using LMS.BlazorApp.Dtos;
using Microsoft.AspNetCore.Components;

namespace LMS.BlazorApp.Shared.Controls
{
    public partial class PurchasedProductTableRow
    {
        [Parameter]
        public PurchasedProductDto PurchasedProduct { get; set; } = new PurchasedProductDto();
        [Parameter]
        public int GroupProductQuantityAvailability { get; set; }
        [Parameter]
        public EventCallback UpdateState { get; set; }

        private bool IsDisabledRow()
        {
            return PurchasedProduct.PurchasedQty - (GroupProductQuantityAvailability + PurchasedProduct.InputPurchasedtQuantity) == 0;
        }
        private int MaxAllowedQuantity()
        {
            return PurchasedProduct.PurchasedQty - GroupProductQuantityAvailability;
        }

        private bool IsInvalidQuantity()
        {
            return IsDisabledRow();
        }
    }
}
