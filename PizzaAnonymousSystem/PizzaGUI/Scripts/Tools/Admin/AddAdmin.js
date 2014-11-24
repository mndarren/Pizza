
$(document).ready(function () {
    document.getElementById("add-admin-reset").onclick = addAdminReset;
    document.getElementById("add-admin-submit").onclick = addAdminSubmit;

    function addAdminReset() {
        event.preventDefault();
        $('#add-admin-name').val("");
        $('#add-admin-address').val("");
        $('#add-admin-city').val("");
        $('#add-admin-state').val("");
        $('#add-admin-zip').val("");
    }

    function addAdminSubmit() {
        event.preventDefault();
        var admin = {
            Name: $('#add-admin-name').val(),
            StreetAddress: $('#add-admin-address').val(),
            city: $('#add-admin-city').val(),
            State: $('#add-admin-state').val(),
            ZipCode: $('#add-admin-zip').val(),
        };

        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/accountmanager/account/admin',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                Name: $('#add-admin-name').val(),
                StreetAddress: $('#add-admin-address').val(),
                City: $('#add-admin-city').val(),
                State: $('#add-admin-state').val(),
                ZipCode: $('#add-admin-zip').val(),
                Status: 0 //default to accepted
            }),
            dataType: "json",
            beforeSend: function () {
                $('#add-admin-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#add-admin-success').slideToggle(400).delay(3000).slideToggle(400);
                addMemberReset();
            },
            error: function (error) {
                $('#add-admin-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#add-admin-loader').addClass("visibility-hidden");
            }
        });
    }
});