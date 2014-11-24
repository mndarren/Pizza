
$(document).ready(function () {
    document.getElementById("get-manager-reset").onclick = getManagerReset;
    document.getElementById("get-manager-submit").onclick = getManagerSubmit;

    function getManagerReset() {
        event.preventDefault();
        $('#get-manager-id').val("");
    }

    function getManagerSubmit() {
        event.preventDefault();

        $.ajax({
            type: 'GET',
            crossDomain: true,
            url: 'http://localhost:49890/api/accountmanager/account/manager' + '/' + $('#get-manager-id').val(),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#get-manager-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#get-manager-success').slideToggle(400).delay(3000).slideToggle(400);
                getManagerReset();
            },
            error: function (error) {
                $('#get-manager-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#get-manager-loader').addClass("visibility-hidden");
            }
        });
    }
});