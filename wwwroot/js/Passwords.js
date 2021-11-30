// In order to use this, the password fields need to have a class of "rsi-password"
// and the checkbox needs a class of "passwordToggle"
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
