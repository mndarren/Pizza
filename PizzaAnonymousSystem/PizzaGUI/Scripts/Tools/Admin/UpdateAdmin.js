
$(document).ready(function () {
    document.getElementById("update-admin-reset").onclick = updateAdminReset;
    document.getElementById("update-admin-submit").onclick = updateAdminSubmit;

    function updateAdminReset() {
        event.preventDefault();
        $('#update-admin-ID').val("");
        $('#update-admin-name').val("");
        $('#update-admin-address').val("");
        $('#update-admin-city').val("");
        $('#update-admin-state').val("");
        $('#update-admin-zip').val("");
    }

    function updateAdminSubmit() {
        event.preventDefault();

        $.ajax({
            type: 'PUT',
            crossDomain: true,
            url: 'http://localhost:49890/api/accountmanager/account/put/admin' + '/' + $('#update-admin-ID').val(),
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                ID:$('#update-admin-ID').val(""),
                Name: $('#update-admin-name').val(),
                StreetAddress: $('#update-admin-address').val(),
                City: $('#update-admin-city').val(),
                State: $('#update-admin-state').val(),
                ZipCode: $('#update-admin-zip').val(),
            }),
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#update-admin-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#update-admin-success').slideToggle(400).delay(3000).slideToggle(400);
                updateAdminReset();
            },
            error: function (error) {
                $('#update-admin-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#update-admin-loader').addClass("visibility-hidden");
            }
        });
    }
});