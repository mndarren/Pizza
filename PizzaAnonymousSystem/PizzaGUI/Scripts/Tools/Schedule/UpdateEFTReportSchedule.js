
$(document).ready(function () {
    document.getElementById("update-schedule-reset").onclick = updateScheduleReset;
    document.getElementById("update-schedule-submit").onclick = updateScheduleSubmit;

    function updateScheduleReset() {
        event.preventDefault();
        $('#update-schedule-time').val("");
        $('#update-schedule-day').val(1);
        $('#update-schedule-report-type').val(0);
    }

    function updateScheduleSubmit() {
        event.preventDefault();

        var reportType = $('#update-schedule-report-type').val();
        if (reportType == 0) updateMemberSchedule();
        else if (reportType == 1) updateProviderSchedule();
        else if (reportType == 2) updateEFTSchedule();
        else updatePayableSchedule();
    }

    function updateMemberSchedule() {
        var weekday = $('#update-schedule-day').val().toString();
        var time = $('#update-schedule-time').val().toString();

        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/reportmanager/schedules/put/memberreport' + '?weekday=' + weekday + '&time=' + time,
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#update-schedule-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#update-schedule-success').slideToggle(400).delay(3000).slideToggle(400);
                updateScheduleReset();
            },
            error: function (error) {
                $('#update-schedule-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#update-schedule-loader').addClass("visibility-hidden");
            }
        });
    }

    function updateProviderSchedule() {
        var weekday = $('#update-schedule-day').val().toString();
        var time = $('#update-schedule-time').val().toString();

        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/reportmanager/schedules/put/providerreport' + '?weekday=' + weekday + '&time=' + time,
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#update-schedule-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#update-schedule-success').slideToggle(400).delay(3000).slideToggle(400);
                updateScheduleReset();
            },
            error: function (error) {
                $('#update-schedule-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#update-schedule-loader').addClass("visibility-hidden");
            }
        });
    }

    function updateEFTSchedule() {
        var weekday = $('#update-schedule-day').val().toString();
        var time = $('#update-schedule-time').val().toString();

        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/reportmanager/schedules/put/eftreport' + '?weekday=' + weekday + '&time=' + time,
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#update-schedule-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#update-schedule-success').slideToggle(400).delay(3000).slideToggle(400);
                updateScheduleReset();
            },
            error: function (error) {
                $('#update-schedule-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#update-schedule-loader').addClass("visibility-hidden");
            }
        });
    }

    function updatePayableSchedule() {
        var weekday = $('#update-schedule-day').val().toString();
        var time = $('#update-schedule-time').val().toString();

        $.ajax({
            type: 'POST',
            crossDomain: true,
            url: 'http://localhost:49890/api/reportmanager/schedules/put/payablereport' + '?weekday=' + weekday + '&time=' + time,
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                $('#update-schedule-loader').removeClass("visibility-hidden");
            },
            success: function (data) {
                $('#update-schedule-success').slideToggle(400).delay(3000).slideToggle(400);
                updateScheduleReset();
            },
            error: function (error) {
                $('#update-schedule-error').slideToggle(400).delay(3000).slideToggle(400);
            },
            complete: function () {
                $('#update-schedule-loader').addClass("visibility-hidden");
            }
        });
    }
});