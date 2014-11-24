$(document).ready(function () {
    document.getElementById("delete-admin-reset").onclick = addAdminReset;
    document.getElementById("delete-admin-submit").onclick = addAdminSubmit;

    function addAdminReset() {
        event.preventDefault();
        $('#delete-admin-ID').val("");
    }

    function addAdminSubmit() {
        event.preventDefault();

        $.ajax({
            type: 'DELETE',
            crossDomain: true,
            url: 'http://localhost:49890/api/accountmanager/account/admin',
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#add-admin-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#add-admin-success').slideToggle(400).delay(3000).slideToggle(400);
                addAdminReset();
            },
            error: function (error) {
                $('#add-admin-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#add-admin-loader').addClass("visibility-hidden");
            }
        });
    }
});