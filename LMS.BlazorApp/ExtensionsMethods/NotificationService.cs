using Microsoft.JSInterop;

namespace LMS.BlazorApp.ExtensionsMethods
{
    public class NotificationService
    {
        private readonly IJSRuntime _jsRuntime;

        public NotificationService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task ShowSuccessNotification(string title, string message)
        {
            await _jsRuntime.InvokeVoidAsync("Swal.fire", title, message, "success");
        }

        public async Task ShowErrorNotification(string title, string message)
        {
            await _jsRuntime.InvokeVoidAsync("Swal.fire", title, message, "error");
        }

        public async Task<bool> ShowConfirmation(string message)
        {
            return await _jsRuntime.InvokeAsync<bool>("showSweetAlertConfirmation", message);
        }
        public async Task<bool> ShowConfirmation(string message, bool useHtml)
        {
            return await _jsRuntime.InvokeAsync<bool>("showSweetAlertConfirmation", message, useHtml);
        }

    }
}
