
$(document).ready(function () {
    document.getElementById("add-manager-reset").onclick = addManagerReset;
    document.getElementById("add-manager-submit").onclick = addManagerSubmit;

    function addManagerReset() {
        event.preventDefault();
        $('#add-manager-name').val("");
        $('#add-manager-address').val("");
        $('#add-manager-city').val("");
        $('#add-manager-state').val("");
        $('#add-manager-zip').val("");
    }

    function addManagerSubmit() {
        event.preventDefault();

        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/accountmanager/account/manager',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                Name: $('#add-manager-name').val(),
                StreetAddress: $('#add-manager-address').val(),
                City: $('#add-manager-city').val(),
                State: $('#add-manager-state').val(),
                ZipCode: $('#add-manager-zip').val(),
                Status: 0 //default to accepted
            }),
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#add-manager-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#add-manager-success').slideToggle(400).delay(3000).slideToggle(400);
                addManagerReset();
            },
            error: function (jqXHR, status, error) {
                var response = jQuery.parseJSON(jqXHR.responseText);
                $('#add-manager-error-message').html(response.Message);
                $('#add-manager-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#add-manager-loader').addClass("visibility-hidden");
            }
        });
    }
});