
$(document).ready(function () {
    document.getElementById("update-provider-reset").onclick = updateProviderReset;
    document.getElementById("update-provider-submit").onclick = updateProviderSubmit;

    function updateProviderReset() {
        event.preventDefault();
        $('update-provider-id').val("");
        $('#update-provider-name').val("");
        $('#update-provider-address').val("");
        $('#update-provider-city').val("");
        $('#update-provider-state').val("");
        $('#update-provider-zip').val("");
        $('#update-provider-bankaccount').val("");
    }

    function updateProviderSubmit() {
        event.preventDefault();

        $.ajax({
            type: 'PUT',
            crossDomain: true,
            url: 'http://localhost:49890/api/accountmanager/account/provider',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                Name: $('#update-provider-name').val(),
                StreetAddress: $('#update-provider-address').val(),
                City: $('#update-provider-city').val(),
                State: $('#update-provider-state').val(),
                ZipCode: $('#update-provider-zip').val(),
                BankAccount: $('#update-provider-bankaccount').val()
            }),
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#update-provider-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#update-provider-success').slideToggle(400).delay(3000).slideToggle(400);
                updateProviderReset();
            },
            error: function (error) {
                $('#update-provider-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#update-provider-loader').addClass("visibility-hidden");
            }
        });
    }
});