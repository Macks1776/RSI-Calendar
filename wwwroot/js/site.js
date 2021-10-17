// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var cal = new tui.Calendar('#month', {
    defaultView: 'month' // monthly view option
});

function password_show_hide() {
    var x = document.getElementById("password");
    var y = document.getElementById("confirmPassword")
    var show_eye = document.getElementById("show_eye");
    var hide_eye = document.getElementById("hide_eye");
    hide_eye.classList.remove("d-none");
    if (x.type === "password" || y.type === "password") {
        x.type = "text";
        y.type = "text";
        show_eye.style.display = "none";
        hide_eye.style.display = "block";
    } else {
        x.type = "password";
        y.type = "password";
        show_eye.style.display = "block";
        hide_eye.style.display = "none";
    }
}