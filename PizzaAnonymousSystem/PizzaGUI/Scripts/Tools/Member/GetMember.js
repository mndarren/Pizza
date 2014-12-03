
$(document).ready(function () {
    document.getElementById("get-member-reset").onclick = getMemberReset;
    document.getElementById("get-member-submit").onclick = getMemberSubmit;

    function getMemberReset() {
        event.preventDefault();
        $('#get-member-id').val("");
    }

    function getMemberSubmit() {
        event.preventDefault();

        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/accountmanager/account/get/member' + '/' + $('#get-member-id').val(),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#get-member-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#get-member-success').slideToggle(400).delay(3000).slideToggle(400);
                $('#get-member-content').removeClass('display-none');
                $('#get-member-name').html(data.Name.toString());
                $('#get-member-address').html(data.StreetAddress.toString());
                $('#get-member-city').html(data.City.toString());
                $('#get-member-state').html(data.State.toString());
                $('#get-member-zip').html(data.ZipCode.toString());
            },
            error: function (jqXHR, status, error) {
                var response = jQuery.parseJSON(jqXHR.responseText);
                $('#get-member-error-message').html(response.Message);
                $('#get-member-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#get-member-loader').addClass("visibility-hidden");
            }
        });
    }
});