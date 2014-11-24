$(document).ready(function () {
    document.getElementById("delete-admin-reset").onclick = deleteAdminReset;
    document.getElementById("delete-admin-submit").onclick = deleteAdminSubmit;

    function deleteAdminReset() {
        event.preventDefault();
        $('#delete-admin-ID').val("");
    }

    function deleteAdminSubmit() {
        event.preventDefault();

        $.ajax({
            type: 'DELETE',
            crossDomain: true,
            url: 'http://localhost:49890/api/accountmanager/account/admin',
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#delete-admin-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#delete-admin-success').slideToggle(400).delay(3000).slideToggle(400);
                addAdminReset();
            },
            error: function (error) {
                $('#delete-admin-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#delete-admin-loader').addClass("visibility-hidden");
            }
        });
    }
});