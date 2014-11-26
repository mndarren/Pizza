
$(document).ready(function () {
    document.getElementById("get-eft-report-submit").onclick = getEFTReport;


    function getEFTReport() {
        event.preventDefault();

        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/reportmanager/reports/eftreport/file',
            contentType: 'application/json; charset=utf-8',
            data: null,
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#report-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
               
                $('#report-success').slideToggle(400).delay(3000).slideToggle(400);
                $("#Report-Id").html('');
               // alert(data);
                var divContent = data;
                $("#Report-Id").html(divContent);
                //alert("data: " + divContent);
                //$("#Report-Id").appent(divContent);
                //window.location;
            },
            error: function (error) {
                $('#report-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#report-loader').addClass("visibility-hidden");
            }
        });
    }
});