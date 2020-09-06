
function sendInteraction(userId, clickedAdUrl, interactionTime, deviceName) {

    $.post("Interactions/Create/", {
        'UserId': userId,
        'ClickedAdUrl': clickedAdUrl,
        'InteractionTime': interactionTime,
        'DeviceName': deviceName,
        'ScreenSize': $(window).width() + 'x' + $(window).height()
    },
        function (data, status) {
            console.log("Status: " + status);
        });

}