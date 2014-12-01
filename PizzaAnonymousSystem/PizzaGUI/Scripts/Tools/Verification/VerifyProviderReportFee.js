$(document).ready(function () {
    document.getElementById("verify-fee-reset").onclick = verifyFeeReset;
    document.getElementById("verify-fee-submit").onclick = verifyFeeSubmit;
    
    function verifyFeeReset() {
        event.preventDefault();
        StartDate: $('#verify-fee-start-date').val("");
        EndDate:$('#verify-fee-end-date').val("");
    }
    
    function verifyFeeSubmit() {
        event.preventDefault();
    
        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/reportmanager/report/providerreport/verification/put/fee',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                ProviderNumber: user.id,
                StartDate: $('#verify-fee-start-date').val(),
                EndDate:$('#verify-fee-end-date').val(),
            }),
    
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#verify-report-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#verify-fee-success').slideToggle(400).delay(3000).slideToggle(400);
                verifyFeeReset();
            },
            error: function (jqXHR, status, error) {
                var response = jQuery.parseJSON(jqXHR.responseText);
                $('#verify-fee-error-message').html(response.Message);
                $('#verify-fee-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#verify-report-loader').addClass("visibility-hidden");
            }
        });
    }
});