
$(document).ready(function () {
    document.getElementById("add-EFTReport-submit").onclick = addManagerSubmit;


    function getEFTReport() {
        event.preventDefault();

        $.ajax({
            type: 'GET',
            crossDomain: true,
            url: 'http://localhost:49890/api/reportmanager/reports/eftreport',
            contentType: 'application/json; charset=utf-8',
          
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#add-EFTReport-loader').removeClass("visibility-hidden");
            },
            success: function (returnValue) {
                $('#add-EFTReport-success').slideToggle(400).delay(3000).slideToggle(400);
                window.location = "http://localhost:49890/api/reportmanager/reports/eftreport?fName=" + returnValue;
            },
            error: function (error) {
                $('#add-EFTReport-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#add-EFTReport-loader').addClass("visibility-hidden");
            }
        });
    }
});