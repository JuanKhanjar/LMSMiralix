function showSweetAlertConfirmation(message, useHtml) {
    return Swal.fire({
        title: 'Confirmation',
        html: useHtml ? message : undefined, // Enable HTML rendering if useHtml is true
        text: !useHtml ? message : undefined, // Use plain text if useHtml is false
        icon: 'question',
        showCancelButton: true,
    }).then((result) => {
        return result.isConfirmed;
    });
}

//Notification for Update
function showSweetAlertSuccess(title, message) {
    Swal.fire({
        title: title,
        text: message,
        icon: 'success'
    });
}

function showValidationError(message) {
    Swal.fire({
        icon: 'warning',
        title: 'Check Validation',
        text: message,
        confirmButtonText: 'OK'
    });
}