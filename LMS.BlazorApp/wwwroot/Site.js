﻿
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
        icon: 'error',
        title: 'Validation Error',
        text: message,
        confirmButtonText: 'OK'
    });
}


