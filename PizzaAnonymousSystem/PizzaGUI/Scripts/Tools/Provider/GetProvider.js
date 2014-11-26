
$(document).ready(function () {
    document.getElementById("get-provider-reset").onclick = getProviderReset;
    document.getElementById("get-provider-submit").onclick = getProviderSubmit;
    
    function getProviderReset() {
        event.preventDefault();
        $('#get-provider-id').val("");
    }
    
    function getProviderSubmit() {
        event.preventDefault();
    
        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/accountmanager/account/get/provider' + '/' + $('#get-provider-id').val(),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#get-provider-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#get-provider-success').slideToggle(400).delay(3000).slideToggle(400);
                $('#get-provider-content').removeClass('display-none');
                $('#get-provider-name').html(data.Name.toString());
                $('#get-provider-address').html(data.StreetAddress.toString());
                $('#get-provider-city').html(data.City.toString());
                $('#get-provider-state').html(data.State.toString());
                $('#get-provider-zip').html(data.ZipCode.toString());
                $('#get-provider-bankaccount').html(data.BankAcount.toString());
            },
            error: function (error) {
                $('#get-provider-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#get-provider-loader').addClass("visibility-hidden");
            }
        });
    }
});