$(document).ready(function () {
    $('.clickable-section').click(function () {
        var $section = $(this);
        var isCollapsed = $section.data('collapsed');

        if (isCollapsed) {
            $section.data('collapsed', false);
            $section.find('.container').show();
            $section.find('#collapseIcon').removeClass('bi-chevron-down').addClass('bi-chevron-up');
        } else {
            $section.data('collapsed', true);
            $section.find('.container').hide();
            $section.find('#collapseIcon').removeClass('bi-chevron-up').addClass('bi-chevron-down');
        }
    });
});
document.addEventListener('DOMContentLoaded', function () {
    console.log('Hello Miralix!');
    const clickableSections = document.querySelectorAll('.clickable-section');

    clickableSections.forEach(function (clickableSection) {
        const groupId = clickableSection.id.split('_')[1]; // Extract the group ID from the element's ID
        const contentToCollapse = document.getElementById('contentToCollapse_' + groupId);
        const collapseIcon = clickableSection.querySelector('.bi-chevron-down');

        clickableSection.addEventListener('click', function () {
            if (contentToCollapse.style.display === 'none') {
                contentToCollapse.style.display = 'block';
                // Change the arrow icon to "up" when content is shown
                collapseIcon.classList.remove('bi-chevron-down');
                collapseIcon.classList.add('bi-chevron-up');
                // Add the "active" class to the section when clicked
                clickableSection.classList.add('active');
            } else {
                contentToCollapse.style.display = 'none';
                // Change the arrow icon to "down" when content is hidden
                collapseIcon.classList.remove('bi-chevron-up');
                collapseIcon.classList.add('bi-chevron-down');
                // Remove the "active" class when content is hidden
                clickableSection.classList.remove('active');
            }
        });
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