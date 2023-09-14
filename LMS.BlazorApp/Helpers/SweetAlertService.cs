using Microsoft.JSInterop;

namespace LMS.BlazorApp.Helpers
{
    public class SweetAlertService
    {
        private readonly IJSRuntime _jsRuntime;

        public SweetAlertService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<bool> ShowConfirmationAsync(string message)
        {
            return await _jsRuntime.InvokeAsync<bool>("showSweetAlertConfirmation", message);
        }

        public async Task ShowSuccessAsync(string title, string message)
        {
            await _jsRuntime.InvokeVoidAsync("showSweetAlertSuccess", title, message);
        }

        public async Task ShowValidationErrorAsync(string message)
        {
            await _jsRuntime.InvokeVoidAsync("showValidationError", message);
        }
    }

}
