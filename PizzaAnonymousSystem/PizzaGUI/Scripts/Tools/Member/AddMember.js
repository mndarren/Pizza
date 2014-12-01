
$(document).ready(function () {
    document.getElementById("add-member-reset").onclick = addMemberReset;
    document.getElementById("add-member-submit").onclick = addMemberSubmit;

    function addMemberReset() {
        event.preventDefault();
        $('#add-member-name').val("");
        $('#add-member-address').val("");
        $('#add-member-city').val("");
        $('#add-member-state').val("");
        $('#add-member-zip').val("");
    }

    function addMemberSubmit() {
        event.preventDefault();
        
        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/accountmanager/account/member',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                Name: $('#add-member-name').val(),
                StreetAddress: $('#add-member-address').val(),
                City: $('#add-member-city').val(),
                State: $('#add-member-state').val(),
                ZipCode: $('#add-member-zip').val(),
                Status: 0 //default to accepted
            }),
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#add-member-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#add-member-success').slideToggle(400).delay(3000).slideToggle(400);
                addMemberReset();
            },
            error: function (jqXHR, status, error) {
                var response = jQuery.parseJSON(jqXHR.responseText);
                $('#add-member-error-message').html(response.Message);
                $('#add-member-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#add-member-loader').addClass("visibility-hidden");
            }
        });
    }
});