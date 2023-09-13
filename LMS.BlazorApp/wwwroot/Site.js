
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

//function showModal(groupId) {
//    console.log("Modal show method called for groupId: " + groupId);
//    var modal = document.getElementById('exampleModal' + groupId);
//    if (modal) {
//        modal.style.display = "block";
//    }
//}

//function hideModal(groupId) {
//    console.log("Modal hide method called for groupId: " + groupId);
//    var modal = document.getElementById('exampleModal' + groupId);
//    if (modal) {
//        modal.style.display = "none";
//        return true;
//    }
//    return false;
//}


function showModal(message) {
    return new Promise((resolve) => {
        var modal = document.querySelector('.modal-overlay');
        if (modal) {
            modal.style.display = 'flex';
            var modalComponent = document.querySelector('.modal');
            if (modalComponent) {
                modalComponent.style.display = 'block';
            }
            document.querySelector('.modal-content p').textContent = message;
        }
        resolve(); // Ensure the promise is resolved
    });
}

function hideModal() {
    return new Promise((resolve) => {
        var modal = document.querySelector('.modal-overlay');
        if (modal) {
            modal.style.display = 'none';
            var modalComponent = document.querySelector('.modal');
            if (modalComponent) {
                modalComponent.style.display = 'none';
            }
        }
        resolve(); // Ensure the promise is resolved
    });
}





