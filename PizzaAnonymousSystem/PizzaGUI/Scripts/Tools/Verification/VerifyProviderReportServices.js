$(document).ready(function () {
    document.getElementById("verify-service-reset").onclick = verifyServiceReset;
    document.getElementById("verify-service-submit").onclick = verifyServiceSubmit;
    
    function verifyServiceReset() {
        event.preventDefault();
        StartDate: $('#verify-fee-start-date');
        EndDate: $('#verify-fee-end-date');
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
                StartDate: $('#verify-service-start-date'),
                EndDate: $('#verify-service-end-date'),
            }),
    
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#verify-service-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#verify-service-success').slideToggle(400).delay(3000).slideToggle(400);
                verifyServiceReset();
            },
            error: function (error) {
                $('#verify-service-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#verify-service-loader').addClass("visibility-hidden");
            }
        });
    }
});