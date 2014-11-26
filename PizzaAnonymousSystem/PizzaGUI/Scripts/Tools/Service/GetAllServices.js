
$(document).ready(function () {

    function AllServicesViewModel() {
        var self = this;

        self.services = ko.observableArray([]);

        self.refreshServices = function () {
            $.ajax({
                type: 'POST',
                crossDomain: true,
                url: 'http://localhost:49890/api/servicemanager/get/services',
                contentType: 'application/json; charset=utf-8',
                dataType: "json",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Access-Control-Allow-Origin", "*");
                    $('#get-member-loader').removeClass("visibility-hidden");
                },
                success: function (data) {
                    $('#get-member-success').slideToggle(400).delay(3000).slideToggle(400);
                    

                },
                error: function (error) {
                    $('#get-member-error').slideToggle(400).delay(3000).slideToggle(400);
                },
                complete: function () {
                    $('#get-member-loader').addClass("visibility-hidden");
                }
            });
        };
    };

    ko.applyBindings(new AllServicesViewModel());

});