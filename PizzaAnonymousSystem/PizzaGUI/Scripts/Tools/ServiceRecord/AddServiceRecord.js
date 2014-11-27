$(document).ready(function () {
    document.getElementById("add-service-record-reset").onclick = addRecordReset;
    document.getElementById("add-service-record-submit").onclick = addRecordSubmit;

    function addRecordReset() {
        event.preventDefault();
        MemberNumber: $('#add-service-record-member-id').val();
        ServiceCode: $('#add-service-record-service-cod').val();
        DateProvided: $('#add-service-record-date').val();
        Comments: $('#add-service-record-comments').val();
    }

    function addRecordSubmit() {
        event.preventDefault();

        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/servicemanager/servicerecords/',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                ProviderNumber: user.id,
                MemberNumber: $('#add-service-record-member-id').val(),
                ServiceCode: $('#add-service-record-service-code').val(),
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
                addRecordReset();
            },
            error: function (jqXHR, status, error) {
                var response = jQuery.parseJSON(jqXHR.responseText);
                $('#add-service-record-error-message').html(response.Message);
                $('#add-record-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#add-record-loader').addClass("visibility-hidden");
            }
        });
    }
});