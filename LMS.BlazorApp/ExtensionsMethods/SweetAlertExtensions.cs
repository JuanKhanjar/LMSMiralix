using Microsoft.JSInterop;

namespace LMS.BlazorApp.ExtensionsMethods
{
    public static class SweetAlertExtensions
    {
        public static async Task ShowValidationErrorAsync(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("Swal.fire", new
            {
                icon = "warning",
                title = "Check Validation",
                text = message,
                confirmButtonText = "OK"
            });
        }

        public static async Task<bool> ShowSweetAlertConfirmationAsync(this IJSRuntime jsRuntime, string message)
        {
            var result = await jsRuntime.InvokeAsync<bool>("Swal.fire", new
            {
                title = "Confirmation",
                text = message,
                icon = "question",
                showCancelButton = true,
                confirmButtonText = "OK" // You can customize the button text here
            });

            return result;
        }



        public static async Task ShowSweetAlertSuccessAsync(this IJSRuntime jsRuntime, string title, string message)
        {
            await jsRuntime.InvokeVoidAsync("Swal.fire", new
            {
                title = title,
                text = message,
                icon = "success"
            });
        }
    }
}
