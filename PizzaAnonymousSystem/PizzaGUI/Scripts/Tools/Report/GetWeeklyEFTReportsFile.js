
$(document).ready(function () {
    document.getElementById("get-eft-report-submit").onclick = getEFTReport;


    function getEFTReport() {
        event.preventDefault();
        alert("1");

        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/reportmanager/reports/eftreport/file',
            contentType: 'application/json; charset=utf-8',
            data: null,
            dataType: "json",
            beforeSend: function (xhr) {
                alert("2");
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#report-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#report-success').slideToggle(400).delay(3000).slideToggle(400);
                $("#Report-Id").html('');
                var divContent = '';
                for (var i = 0; i < data.length; i++) {
                    divContent += '<p>' + data[i].Name + '</p>'; //if Name is property of your Person object
                }
                $("#Report-Id").appent(divContent);
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