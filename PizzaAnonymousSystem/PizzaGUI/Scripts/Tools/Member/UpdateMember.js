

$(document).ready(function () {
    document.getElementById("update-member-reset").onclick = updateMemberReset;
    document.getElementById("update-member-submit").onclick = updateMemberSubmit;

    function updateMemberReset() {
        event.preventDefault();
        $('#update-member-name').val("");
        $('#update-member-address').val("");
        $('#update-member-city').val("");
        $('#update-member-state').val("");
        $('#update-member-zip').val("");
    }

    function updateMemberSubmit() {
        event.preventDefault();

        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/accountmanager/account/put/member',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                ID: $('#update-member-id').val(),
                Name: $('#update-member-name').val(),
                StreetAddress: $('#update-member-address').val(),
                City: $('#update-member-city').val(),
                State: $('#update-member-state').val(),
                ZipCode: $('#update-member-zip').val(),
                Status: $('#update-member-status').val()
            }),
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#update-member-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#update-member-success').slideToggle(400).delay(3000).slideToggle(400);
                addMemberReset();
            },
            error: function (error) {
                $('#update-member-error-message').html(error);
                $('#update-member-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#update-member-loader').addClass("visibility-hidden");
            }
        });
    }
});