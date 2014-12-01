$(document).ready(function () {
    document.getElementById("vaildate-fee-reset").onclick = vaildateFeeReset;
    document.getElementById("vaildate-fee-submit").onclick = vaildateFeeSubmit;
    
    function vaildateFeeReset() {
        event.preventDefault();
        StartDate: $('#verify-fee-start-date');
        EndDate:$('#verify-fee-end-date');
    }
    
    function vaildateFeeSubmit() {
        event.preventDefault();
    
        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/reportmanager/report/providerreport/verification/put/fee',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                ProviderNumber: user.id,
                StartDate: $('#verify-fee-start-date'),
                EndDate:$('#verify-fee-end-date'),
            }),
    
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#vaildate-fee-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#vaildate-fee-success').slideToggle(400).delay(3000).slideToggle(400);
                vaildateFeeReset();
            },
            error: function (error) {
                $('#vaildate-fee-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#vaildate-fee-loader').addClass("visibility-hidden");
            }
        });
    }
});