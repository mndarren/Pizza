
$(document).ready(function () {
    document.getElementById("delete-member-reset").onclick = deleteMemberReset;
    document.getElementById("delete-member-submit").onclick = deleteMemberSubmit;

    function deleteMemberReset() {
        event.preventDefault();
        $('#delete-member-id').val("");
    }

    function deleteMemberSubmit() {
        event.preventDefault();

        $.ajax({
            type: 'DELETE',
            crossDomain: true,
            url: 'http://localhost:49890/api/accountmanager/account/member' + '/' + $('#delete-member-id').val(),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#delete-member-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#delete-member-success').slideToggle(400).delay(3000).slideToggle(400);
                deleteMemberReset();
            },
            error: function (jqXHR, status, error) {
                try {
                    var response = jQuery.parseJSON(jqXHR.responseText);
                    $('#delete-member-error-message').html(response.Message);
                } catch (err) {
                    $('#delete-member-error-message').html("");
                } finally {
                    $('#delete-member-error').slideToggle(400).delay(3000).slideToggle(400);
                }
            },
            complete: function () {
                $('#delete-member-loader').addClass("visibility-hidden");
            }
        });
    }
});