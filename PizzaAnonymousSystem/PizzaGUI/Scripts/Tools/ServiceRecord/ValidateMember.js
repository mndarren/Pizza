$(document).ready(function () {
    //document.getElementById("vaildate-member-reset").onclick = vaildateMemberReset;
    document.getElementById("validate-member").onclick = vaildateMemberSubmit;

    function vaildateMemberReset() {
        event.preventDefault();
        MemberNumber: $('#validate-memberID').val();
    }

    function vaildateMemberSubmit() {
        event.preventDefault();

        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/accountmanager/validation/member/' + $('#add-service-record-member-id').val(),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#add-service-record-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                //$('#add-service-record-success').slideToggle(400).delay(3000).slideToggle(400);
                $('#validate-member-status').html(data);

                if (data.toString() == "VALID") {
                    $('#validate-member-status').addClass('color-green');
                    $('#validate-member-status').removeClass('color-red');
                    $('#add-service-record-submit').removeAttr("disabled");
                } else {
                    $('#validate-member-status').addClass('color-red');
                    $('#validate-member-status').removeClass('color-green');
                    $('#add-service-record-submit').attr("disabled", "disabled");
                }
                $('#validate-member-status').removeClass('visibility-hidden');
                //vaildateMemberReset();
            },
            error: function (jqXHR, status, error) {
                try {
                    var response = jQuery.parseJSON(jqXHR.responseText);
                    $('#add-service-record-error-message').html(response.Message);
                } catch (err) {
                    $('#add-service-record-error-message').html("");
                } finally {
                    $('#add-service-record-error').slideToggle(400).delay(3000).slideToggle(400);
                }
            },
            complete: function () {
                $('#add-service-record-loader').addClass("visibility-hidden");
            }
        });
    }
});