
$(document).ready(function () {
    document.getElementById("get-admin-reset").onclick = getAdminReset;
    document.getElementById("get-admin-submit").onclick = getAdminrSubmit;

    function getAdminReset() {
        event.preventDefault();
        $('#get-admin-id').val("");
    }

    function getAdminrSubmit() {
        event.preventDefault();

        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/accountmanager/account/get/admin' + '/' + $('#get-admin-id').val(),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#get-admin-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#get-admin-success').slideToggle(400).delay(3000).slideToggle(400);
                $('#get-admin-content').removeClass('display-none');
                $('#get-admin-name').html(data.Name.toString());
                $('#get-admin-address').html(data.StreetAddress.toString());
                $('#get-admin-city').html(data.City.toString());
                $('#get-admin-state').html(data.State.toString());
                $('#get-admin-zip').html(data.ZipCode.toString());
            },
            error: function (jqXHR, status, error) {
                var response = jQuery.parseJSON(jqXHR.responseText);
                $('#get-admin-error-message').html(response.Message);
                $('#get-admin-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#get-admin-loader').addClass("visibility-hidden");
            }
        });
    }
});