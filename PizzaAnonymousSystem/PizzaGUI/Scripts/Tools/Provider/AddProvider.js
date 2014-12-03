
$(document).ready(function () {
    document.getElementById("add-provider-reset").onclick = addProviderReset;
    document.getElementById("add-provider-submit").onclick = addProviderSubmit;

    function addProviderReset() {
        event.preventDefault();
        $('#add-provider-name').val("");
        $('#add-provider-address').val("");
        $('#add-provider-city').val("");
        $('#add-provider-state').val("");
        $('#add-provider-zip').val("");
        $('#add-provider-bankaccount').val("");
    }

    function addProviderSubmit() {
        event.preventDefault();

        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/accountmanager/account/provider',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                Name: $('#add-provider-name').val(),
                StreetAddress: $('#add-provider-address').val(),
                City: $('#add-provider-city').val(),
                State: $('#add-provider-state').val(),
                ZipCode: $('#add-provider-zip').val(),
                BankAccount: $('#add-provider-bankaccount').val()
            }),
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#add-provider-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#add-provider-success').slideToggle(400).delay(3000).slideToggle(400);
                addProviderReset();
            },
            error: function (jqXHR, status, error) {
                try {
                    var response = jQuery.parseJSON(jqXHR.responseText);
                    $('#add-provider-error-message').html(response.Message);
                } catch (err) {
                    $('#add-provider-error-message').html("");
                } finally {
                    $('#add-provider-error').slideToggle(400).delay(3000).slideToggle(400);
                }
            },
            complete: function () {
                $('#add-provider-loader').addClass("visibility-hidden");
            }
        });
    }
});