$(document).ready(function () {
    document.getElementById("delete-admin-reset").onclick = deleteAdminReset;
    document.getElementById("delete-admin-submit").onclick = deleteAdminSubmit;


    function deleteAdminReset() {
        event.preventDefault();
        $('#delete-admin-ID').val("");
    }

    function deleteAdminSubmit() {
        event.preventDefault();
        if ($('#delete-admin-ID').val() != user.id) { //temporary fix
            $.ajax({
                type: 'DELETE',
                crossDomain: true,
                url: 'http://localhost:49890/api/accountmanager/account/admin' + '/' + $('#delete-admin-ID').val(),
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
                error: function (jqXHR, status, error) {
                    try {
                        var response = jQuery.parseJSON(jqXHR.responseText);
                        $('#delete-admin-error-message').html(response.Message);
                    } catch (err) {
                        $('#delete-admin-error-message').html("");
                    } finally {
                        $('#delete-admin-error').slideToggle(400).delay(3000).slideToggle(400);
                    }
                },
                complete: function () {
                    $('#delete-admin-loader').addClass("visibility-hidden");
                }
            });
        } else {
            $('#delete-admin-error-message').html(" unable to delete your own account!");
            $('#delete-admin-error').slideToggle(400).delay(3000).slideToggle(400);
        }
    }
});