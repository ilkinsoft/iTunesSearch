
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

// search fails
function onFailure_Message() {
    $('#unauthorizedMessage').text('You are not authorized. Please login before searching.').show()
}

// search success
function onSuccess_Message() {
    console.log('success')
}