$(document).ready(function () {
    document.getElementById("vaildate-service-reset").onclick = vaildateServiceReset;
    document.getElementById("vaildate-service-submit").onclick = vaildateServiceSubmit;
    
    function vaildateMemberReset() {
        event.preventDefault();
        ProviderNumber: $('#Service-Record-ProviderID').val();
    }
    
    function vaildateServiceSubmit() {
        event.preventDefault();
    
        $.ajax({
            type: 'PUT',
            crossDomain: true,
            url: 'http://localhost:49890/api/reportmanager/report/providerreport/verification/service',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                ProviderNumber: $('#Service-Record-ProviderID').val(),
            }),
    
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#vaildate-service-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#vaildate-service-success').slideToggle(400).delay(3000).slideToggle(400);
                vaildateServiceReset();
            },
            error: function (error) {
                $('#vaildate-service-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#vaildate-service-loader').addClass("visibility-hidden");
            }
        });
    }
});