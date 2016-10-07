var GrafanaDemo = {
    init: function () {
        
        console.log("Grafana Demo inited");
    },

    setupInterestEvent: function () {
        $("#btnInterest1").bind("click", function () {
            GrafanaDemo.sendInterestEvent('1');
        });

        $("#btnInterest2").bind("click", function () {
            GrafanaDemo.sendInterestEvent('2');
        });

        $("#btnInterest3").bind("click", function () {
            GrafanaDemo.sendInterestEvent('3');
        });
    },

    setupBookingEvent: function () {
        $("#btnBooking1").bind("click", function () {
            GrafanaDemo.sendBookingEvent('1');
        });

        $("#btnBooking2").bind("click", function () {
            GrafanaDemo.sendBookingEvent('2');
        });

        $("#btnBooking3").bind("click", function () {
            GrafanaDemo.sendBookingEvent('3');
        });
    },

    setupCartEvent: function () {
        $("#btnPayment").bind("click", function () {
            GrafanaDemo.sendPaymentEvent('20000');
        });

        $("#btnCancel1").bind("click", function () {
            GrafanaDemo.sendCancelEvent('1');
        });

        $("#btnCancel2").bind("click", function () {
            GrafanaDemo.sendCancelEvent('2');
        });

        $("#btnCancel3").bind("click", function () {
            GrafanaDemo.sendCancelEvent('3');
        });
    },

    sendInterestEvent: function (id) {
        $.post("/api/metric/interest/" + id, { id: id });
    },

    sendBookingEvent: function (id) {
        $.post("/api/metric/booking/" + id, { id: id });
    },

    sendCancelEvent: function (id) {
        $.post("/api/metric/cancel/" + id, { id: id });
    },

    sendPaymentEvent: function (id) {
        $.post("/api/metric/payment/" + id, { id: id });
    }




};;