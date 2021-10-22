
function toggle_password() {
    var passwordFields = document.getElementsByClassName("rsi-password");
    const chkBoxShowPassword = document.querySelector(".passwordToggle");
    
    if (chkBoxShowPassword.checked) {
        for (let i = 0; i < passwordFields.length; i++) {
            passwordFields[i].type = "text";
        }
    } else {
        for (let i = 0; i < passwordFields.length; i++) {
            passwordFields[i].type = "password";
        }
    }
}
