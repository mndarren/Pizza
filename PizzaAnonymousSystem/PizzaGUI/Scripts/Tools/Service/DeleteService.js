
$(document).ready(function () {
    document.getElementById("delete-service-reset").onclick = deleteServiceReset;
    document.getElementById("delete-service-submit").onclick = deleteServiceSubmit;

    function deleteServiceReset() {
        event.preventDefault();
        $('#delete-service-code').val("");
    }

    function deleteServiceSubmit() {
        event.preventDefault();

        $.ajax({
            type: 'DELETE',
            crossDomain: true,
            url: 'http://localhost:49890/api/servicemanager/services/' + '/' + $('#delete-service-code').val(),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#delete-service-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#delete-service-success').slideToggle(400).delay(3000).slideToggle(400);
                deleteServiceReset();
            },
            error: function (error) {
                $('#delete-service-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#delete-service-loader').addClass("visibility-hidden");
            }
        });
    }
});