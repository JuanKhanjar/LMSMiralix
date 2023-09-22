
function showValidationError(message) {
    alert(message);
}
//Create Group
function showNotification(message, type) {
    // Customize this function to display notifications as per your UI framework or library
    // For example, you can use a toast library or custom HTML/CSS to display notifications
    if (type === "success") {
        // Show a success notification
        alert(message, type)
        console.log("Success: " + message);
        // You can use a toast library here or update your UI accordingly
    } else if (type === "error") {
        // Show an error notification
        alert(message, type)
        console.error("Error: " + message);
        // You can use a toast library here or update your UI accordingly
    }
}

//sweet-alert.js
// wwwroot/js/site.js

function showValidationError(message) {
    Swal.fire({
        icon: 'warning',
        title: 'Check Validation',
        text: message,
        confirmButtonText: 'OK'
    });
}


//Update Confirmation
//function showSweetAlertConfirmation(message) {
//    return Swal.fire({
//        title: 'Confirmation',
//        text: message,
//        icon: 'question',
//        showCancelButton: true,
//    }).then((result) => {
//        return result.isConfirmed;
//    });
//}
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
// Create a JavaScript function outside of any class






