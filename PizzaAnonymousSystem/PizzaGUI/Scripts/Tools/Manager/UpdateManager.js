
$(document).ready(function () {
    document.getElementById("update-manager-reset").onclick = updateManagerReset;
    document.getElementById("update-manager-submit").onclick = updateManagerSubmit;

    function updateManagerReset() {
        event.preventDefault();
        $('#update-manager-name').val("");
        $('#update-manager-address').val("");
        $('#update-manager-city').val("");
        $('#update-manager-state').val("");
        $('#update-manager-zip').val("");
    }

    function updateManagerSubmit() {
        event.preventDefault();

        $.ajax({
            type: 'PUT',
            crossDomain: true,
            url: 'http://localhost:49890/api/accountmanager/account/manager',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                Name: $('#update-manager-name').val(),
                StreetAddress: $('#update-manager-address').val(),
                City: $('#update-manager-city').val(),
                State: $('#update-manager-state').val(),
                ZipCode: $('#update-manager-zip').val(),
                Status: 0 //default to accepted
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
            error: function (error) {
                $('#update-manager-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#update-manager-loader').addClass("visibility-hidden");
            }
        });
    }
});