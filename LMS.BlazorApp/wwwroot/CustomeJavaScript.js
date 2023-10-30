document.addEventListener('DOMContentLoaded', function () {
    var icon = document.getElementById('collapseIcon_@(group.GroupId)');
    var collapseSection = document.getElementById('collapse_@(group.GroupId)');

    collapseSection.addEventListener('show.bs.collapse', function () {
        // When the collapsible section is shown (expanded), change the icon to 'up'
        icon.classList.remove('bi-chevron-down');
        icon.classList.add('bi-chevron-up');
    });

    collapseSection.addEventListener('hide.bs.collapse', function () {
        // When the collapsible section is hidden (collapsed), change the icon to 'down'
        icon.classList.remove('bi-chevron-up');
        icon.classList.add('bi-chevron-down');
    });
});

//// Get the modal
//var modal = document.getElementById('id01');
//// When the user clicks anywhere outside of the modal, close it
//window.onclick = function (event) {
//    if (event.target == modal) {
//        modal.style.display = 'none';
//    }
//};
//document.addEventListener('DOMContentLoaded', function () {
//    // Click event handler for the "Slet Gruppe" (delete) button
//    var deleteButton = document.getElementById('123');
//    if (deleteButton) {
//        deleteButton.addEventListener('click', function () {
//            // Perform your delete actions here (e.g., AJAX request to delete the group on the server)
//            // Simulating a 2-second delay for demonstration purposes
//            console.log('Group deleted successfully'); // Log a success message
//        });
//    }

//    // Click event handler for the "Annullere" (cancel) button
//    var cancelButton = document.querySelector('.cancelbtn');
//    if (cancelButton) {
//        cancelButton.addEventListener('click', function () {
//            var modal = document.getElementById('id01');
//            if (modal) {
//                modal.style.display = 'none'; // Close the modal
//            }
//        });
//    }
//});