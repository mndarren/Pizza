
$(document).ready(function () {
    document.getElementById("get-one-member-submit").onclick = getMemberReport;
   


    function getMemberReport() {
        event.preventDefault();
        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/reportmanager/reports/onememberreport/'+ $('#member-id').val(),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            beforeSend: function (xhr) {
                $("#Report-Id").html('No result!');
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#report-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#report-success').slideToggle(400).delay(3000).slideToggle(400);
                $("#Report-Id").html('');
                // alert(data);
                var divContent = data;
                $("#Report-Id").html(divContent);
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