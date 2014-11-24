
$(document).ready(function () {
    document.getElementById("add-service-reset").onclick = addServiceReset;
    document.getElementById("add-service-submit").onclick = addServiceSubmit;

    function addServiceReset() {
        event.preventDefault();
        $('#add-service-code').val("");
        $('#add-service-name').val("");
        $('#add-service-fee').val("");
    }

    function addServiceSubmit() {
        event.preventDefault();

        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/servicemanager/services/',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                ServiceName: $('#add-service-name').val(),
                ServiceCode: $('#add-service-code').val(),
                ServiceFee: $('#add-service-fee').val()
            }),
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#add-service-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#add-service-success').slideToggle(400).delay(3000).slideToggle(400);
                addServiceReset();
            },
            error: function (error) {
                $('#add-service-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#add-service-loader').addClass("visibility-hidden");
            }
        });
    }
});