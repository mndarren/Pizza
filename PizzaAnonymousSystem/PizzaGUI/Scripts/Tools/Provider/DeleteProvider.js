
$(document).ready(function () {
    document.getElementById("delete-provider-reset").onclick = deleteProviderReset;
    document.getElementById("delete-provider-submit").onclick = deleteProviderSubmit;

    function deleteProviderReset() {
        event.preventDefault();
        $('#delete-provider-id').val("");
    }

    function deleteProviderSubmit() {
        event.preventDefault();

        $.ajax({
            type: 'DELETE',
            crossDomain: true,
            url: 'http://localhost:49890/api/accountmanager/account/provider' + '/' + $('#delete-provider-id').val(),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#delete-provider-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#delete-provider-success').slideToggle(400).delay(3000).slideToggle(400);
                deleteProviderReset();
            },
            error: function (error) {
                $('#delete-provider-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#delete-provider-loader').addClass("visibility-hidden");
            }
        });
    }
});