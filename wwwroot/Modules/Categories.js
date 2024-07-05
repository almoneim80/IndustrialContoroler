
$("#acceptRequestsDiv").hide();
$("#rejectRequestsDiv").hide();
$("#RequestsRWaitingDiv").hide();

document.getElementById("newRequests").style.color = "Blue";

if ($('html').hasClass('dark-style')) {

    $("#newRequests").click(function () {
        $("#newRequestsDiv").show();
        $("#acceptRequestsDiv").hide();
        $("#rejectRequestsDiv").hide();
        $("#RequestsRWaitingDiv").hide();

        document.getElementById("newRequests").style.color = "Blue";
        document.getElementById("acceptRequests").style.color = "white";
        document.getElementById("rejectRequests").style.color = "white";
        document.getElementById("RequestsRWaiting").style.color = "white";
    });


    $("#acceptRequests").click(function () {
        $("#newRequestsDiv").hide();
        $("#acceptRequestsDiv").show();
        $("#rejectRequestsDiv").hide();
        $("#RequestsRWaitingDiv").hide();

        document.getElementById("newRequests").style.color = "white";
        document.getElementById("acceptRequests").style.color = "Blue";
        document.getElementById("rejectRequests").style.color = "white";
        document.getElementById("RequestsRWaiting").style.color = "white";
    });


    $("#rejectRequests").click(function () {
        $("#newRequestsDiv").hide();
        $("#acceptRequestsDiv").hide();
        $("#rejectRequestsDiv").show();
        $("#RequestsRWaitingDiv").hide();

        document.getElementById("newRequests").style.color = "white";
        document.getElementById("acceptRequests").style.color = "white";
        document.getElementById("rejectRequests").style.color = "Blue";
        document.getElementById("RequestsRWaiting").style.color = "white";
    });


    $("#RequestsRWaiting").click(function () {
        $("#newRequestsDiv").hide();
        $("#acceptRequestsDiv").hide();
        $("#rejectRequestsDiv").hide();
        $("#RequestsRWaitingDiv").show();

        document.getElementById("newRequests").style.color = "white";
        document.getElementById("acceptRequests").style.color = "white";
        document.getElementById("rejectRequests").style.color = "white";
        document.getElementById("RequestsRWaiting").style.color = "Blue";
    });

}
else {
    $("#newRequests").click(function () {
        $("#newRequestsDiv").show();
        $("#acceptRequestsDiv").hide();
        $("#rejectRequestsDiv").hide();
        $("#RequestsRWaitingDiv").hide();

        document.getElementById("newRequests").style.color = "Blue";
        document.getElementById("acceptRequests").style.color = "#516377";
        document.getElementById("rejectRequests").style.color = "#516377";
        document.getElementById("RequestsRWaiting").style.color = "#516377";
    });


    $("#acceptRequests").click(function () {
        $("#newRequestsDiv").hide();
        $("#acceptRequestsDiv").show();
        $("#rejectRequestsDiv").hide();
        $("#RequestsRWaitingDiv").hide();

        document.getElementById("newRequests").style.color = "#516377";
        document.getElementById("acceptRequests").style.color = "Blue";
        document.getElementById("rejectRequests").style.color = "#516377";
        document.getElementById("RequestsRWaiting").style.color = "#516377";
    });


    $("#rejectRequests").click(function () {
        $("#newRequestsDiv").hide();
        $("#acceptRequestsDiv").hide();
        $("#rejectRequestsDiv").show();
        $("#RequestsRWaitingDiv").hide();

        document.getElementById("newRequests").style.color = "#516377";
        document.getElementById("acceptRequests").style.color = "#516377";
        document.getElementById("rejectRequests").style.color = "Blue";
        document.getElementById("RequestsRWaiting").style.color = "#516377";
    });


    $("#RequestsRWaiting").click(function () {
        $("#newRequestsDiv").hide();
        $("#acceptRequestsDiv").hide();
        $("#rejectRequestsDiv").hide();
        $("#RequestsRWaitingDiv").show();

        document.getElementById("newRequests").style.color = "#516377";
        document.getElementById("acceptRequests").style.color = "#516377";
        document.getElementById("rejectRequests").style.color = "#516377";
        document.getElementById("RequestsRWaiting").style.color = "Blue";
    });

}