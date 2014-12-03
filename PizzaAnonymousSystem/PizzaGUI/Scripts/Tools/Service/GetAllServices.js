
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
                    $('#get-all-services-loader').removeClass("visibility-hidden");
                },
                success: function (data) {
                    //$('#get-all-services-success').slideToggle(400).delay(3000).slideToggle(400);

                    self.services([]);
                    var newServices = data;
                    ko.utils.arrayForEach(newServices, function (service) {
                        self.services.push({
                            serviceCode: service.ServiceCode,
                            name: service.ServiceName,
                            fee: service.ServiceFee
                        });
                    });
                },
                error: function (jqXHR, status, error) {
                    try {
                        var response = jQuery.parseJSON(jqXHR.responseText);
                        $('#get-all-services-error-message').html(response.Message);
                    } catch (err) {
                        $('#get-all-services-error-message').html("");
                    } finally {
                        $('#get-all-services-error').slideToggle(400).delay(3000).slideToggle(400);
                    }
                },
                complete: function () {
                    $('#get-all-services-loader').addClass("visibility-hidden");
                }
            });
        };
        self.refreshServices(); //Initial values
    };

    ko.applyBindings(new AllServicesViewModel());

});