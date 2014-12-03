$(document).ready(function () {
    document.getElementById("verify-service-reset").onclick = verifyServiceReset;
    document.getElementById("verify-service-submit").onclick = verifyServiceSubmit;
    
    function verifyServiceReset() {
        event.preventDefault();
        StartDate: $('#verify-service-start-date').val("");
        EndDate: $('#verify-service-end-date').val("");
    }
    
    function verifyServiceSubmit() {
        event.preventDefault();
    
        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/reportmanager/report/providerreport/verification/put/service',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                ProviderNumber: user.id,
                StartDate: $('#verify-service-start-date').val(),
                EndDate: $('#verify-service-end-date').val(),
            }),
    
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#verify-report-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#verify-services-success').slideToggle(400).delay(3000).slideToggle(400);
                verifyServiceReset();
            },
            error: function (jqXHR, status, error) {
                try {
                    var response = jQuery.parseJSON(jqXHR.responseText);
                    $('#verify-services-error-message').html(response.Message);
                } catch (err) {
                    $('#verify-services-error-message').html("");
                } finally {
                    $('#verify-services-error').slideToggle(400).delay(3000).slideToggle(400);
                }
            },
            complete: function () {
                $('#verify-report-loader').addClass("visibility-hidden");
            }
        });
    }
});