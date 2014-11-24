$(document).ready(function () {
    document.getElementById("add-record-reset").onclick = addAdminReset;
    document.getElementById("add-record-submit").onclick = addAdminSubmit;

    function addAdminReset() {
        event.preventDefault();
        MemberNumber: $('#add-service-record-member-id').val();
        ServiceCode: $('#add-service-record-service-cod').val();
        DateProvided: $('#add-service-record-date').val();
        Comments: $('#add-service-record-comments').val();
    }

    function addAdminSubmit() {
        event.preventDefault();

        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/servicemanager/servicerecords/',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                MemberNumber: $('#add-service-record-member-id').val(),
                ServiceCode: $('#add-service-record-service-cod').val(),
                DateProvided: $('#add-service-record-date').val(),
                Comments: $('#add-service-record-comments').val(),
            }),

            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#add-record-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#add-record-success').slideToggle(400).delay(3000).slideToggle(400);
                addAdminReset();
            },
            error: function (error) {
                $('#add-record-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#add-record-loader').addClass("visibility-hidden");
            }
        });
    }
});