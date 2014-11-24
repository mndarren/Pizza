
$(document).ready(function () {
    document.getElementById("delete-manager-reset").onclick = deleteManagerReset;
    document.getElementById("delete-manager-submit").onclick = deleteManagerSubmit;

    function deleteManagerReset() {
        event.preventDefault();
        $('#delete-manager-id').val("");
    }

    function deleteManagerSubmit() {
        event.preventDefault();

        $.ajax({
            type: 'DELETE',
            crossDomain: true,
            url: 'http://localhost:49890/api/accountmanager/account/manager' + '/' + $('#delete-manager-id').val(),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#delete-manager-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#delete-manager-success').slideToggle(400).delay(3000).slideToggle(400);
                deleteManagerReset();
            },
            error: function (error) {
                $('#delete-manager-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#delete-manager-loader').addClass("visibility-hidden");
            }
        });
    }
});