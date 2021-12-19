/* When the user clicks on the button,
    toggle between hiding and showing the dropdown content */
function dropDown() {
    document.getElementById("showCourses").classList.toggle("show");
}

// Close the dropdown if the user clicks outside of it
window.onclick = function (event) {
    if (event.target.matches('#reqClose')) {
        document.getElementById("showCourses").classList.toggle("show");
    }
}

