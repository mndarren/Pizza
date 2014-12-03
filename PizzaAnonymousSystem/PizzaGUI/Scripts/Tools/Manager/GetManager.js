
$(document).ready(function () {
    document.getElementById("get-manager-reset").onclick = getManagerReset;
    document.getElementById("get-manager-submit").onclick = getManagerSubmit;

    function getManagerReset() {
        event.preventDefault();
        $('#get-manager-id').val("");
    }

    function getManagerSubmit() {
        event.preventDefault();

        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/accountmanager/account/get/manager' + '/' + $('#get-manager-id').val(),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#get-manager-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#get-manager-success').slideToggle(400).delay(3000).slideToggle(400);
                $('#get-manager-content').removeClass('display-none');
                $('#get-manager-name').html(data.Name.toString());
                $('#get-manager-address').html(data.StreetAddress.toString());
                $('#get-manager-city').html(data.City.toString());
                $('#get-manager-state').html(data.State.toString());
                $('#get-manager-zip').html(data.ZipCode.toString());
            },
            error: function (jqXHR, status, error) {
                try {
                    var response = jQuery.parseJSON(jqXHR.responseText);
                    $('#get-manager-error-message').html(response.Message);
                } catch (err) {
                    $('#get-manager-error-message').html("");
                } finally {
                    $('#get-manager-error').slideToggle(400).delay(3000).slideToggle(400);
                }
            },
            complete: function () {
                $('#get-manager-loader').addClass("visibility-hidden");
            }
        });
    }
});