using LMS.BlazorApp.Dtos;
using Microsoft.AspNetCore.Components;

namespace LMS.BlazorApp.Shared.Controls
{
    public partial class PurchasedProductTableRow
    {
        [Parameter]
        public PurchasedProductDto PurchasedProduct { get; set; } = new PurchasedProductDto();
        [Parameter]
        public int GroupProductQuantity { get; set; }
    }
}
