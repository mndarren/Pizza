
$(document).ready(function () {
    document.getElementById("login-btn-reset").onclick = resetLoginBox;
    document.getElementById("login-btn-submit").onclick = submitLoginBox;

    function resetLoginBox() {
        event.preventDefault();
        $('#login-role').val(1);
        $('#login-id').val("");
    }

    function submitLoginBox() { //Temporary. Link to actual function later
        event.preventDefault();
        var role = parseInt($('#login-role').val());

        if ($('#login-id').val() != "") {
            if (role == 3) window.location = login.adminPath;
            else if (role == 2) window.location = login.managerPath;
            else window.location = login.providerPath;
        } else {
            $('#login-error').slideToggle(400).delay(3000).slideToggle(400);
        }
    }
});