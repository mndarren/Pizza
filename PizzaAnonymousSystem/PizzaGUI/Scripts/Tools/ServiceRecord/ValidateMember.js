$(document).ready(function () {
    document.getElementById("vaildate-member-reset").onclick = vaildateMemberReset;
    document.getElementById("vaildate-member-submit").onclick = vaildateMemberSubmit;

    function vaildateMemberReset() {
        event.preventDefault();
        MemberNumber: $('#validate-memberID').val();
    }

    function vaildateMemberSubmit() {
        event.preventDefault();

        $.ajax({
            type: 'GET',
            crossDomain: true,
            url: 'http://localhost:49890/api/accountmanager/validation/member/',
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#vaildate-memberd-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#vaildate-member-success').slideToggle(400).delay(3000).slideToggle(400);
                vaildateMemberReset();
            },
            error: function (error) {
                $('#vaildate-member-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#vaildate-member-loader').addClass("visibility-hidden");
            }
        });
    }
});