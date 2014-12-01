
$(document).ready(function () {
    document.getElementById("update-manager-reset").onclick = updateManagerReset;
    document.getElementById("update-manager-submit").onclick = updateManagerSubmit;

    function updateManagerReset() {
        event.preventDefault();
        $('#update-manager-id').val("");
        $('#update-manager-name').val("");
        $('#update-manager-address').val("");
        $('#update-manager-city').val("");
        $('#update-manager-state').val("");
        $('#update-manager-zip').val("");
    }

    function updateManagerSubmit() {
        event.preventDefault();
        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/accountmanager/account/put/manager',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                ID:$('#update-manager-id').val(),
                Name: $('#update-manager-name').val(),
                StreetAddress: $('#update-manager-address').val(),
                City: $('#update-manager-city').val(),
                State: $('#update-manager-state').val(),
                ZipCode: $('#update-manager-zip').val(),
            }),
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#update-manager-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#update-manager-success').slideToggle(400).delay(3000).slideToggle(400);
                updateManagerReset();
            },
            error: function (jqXHR, status, error) {
                var response = jQuery.parseJSON(jqXHR.responseText);
                $('#update-manager-error-message').html(response.Message);
                $('#update-manager-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#update-manager-loader').addClass("visibility-hidden");
            }
        });
    }
});