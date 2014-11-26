$(document).ready(function () {
    //document.getElementById("vaildate-fee-reset").onclick = vaildateFeeReset;
    //document.getElementById("vaildate-fee-submit").onclick = vaildateFeeSubmit;
    //
    //function vaildateFeeReset() {
    //    event.preventDefault();
    //    ProviderNumber: $('#Service-Record-ProviderID').val();
    //}
    //
    //function vaildateFeeSubmit() {
    //    event.preventDefault();
    //
    //    $.ajax({
    //        type: 'PUT',
    //        crossDomain: true,
    //        url: 'http://localhost:49890/api/reportmanager/report/providerreport/verification/fee',
    //        contentType: 'application/json; charset=utf-8',
    //        data: JSON.stringify({
    //            ProviderNumber: $('#Service-Record-ProviderID').val(),
    //        }),
    //
    //        dataType: "json",
    //        beforeSend: function (xhr) {
    //            xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
    //            $('#vaildate-fee-loader').removeClass("visibility-hidden");
    //        },
    //        success: function (data) {
    //            $('#vaildate-fee-success').slideToggle(400).delay(3000).slideToggle(400);
    //            vaildateFeeReset();
    //        },
    //        error: function (error) {
    //            $('#vaildate-fee-error').slideToggle(400).delay(3000).slideToggle(400);
    //        },
    //        complete: function () {
    //            $('#vaildate-fee-loader').addClass("visibility-hidden");
    //        }
    //    });
    //}
});