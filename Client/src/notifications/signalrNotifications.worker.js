// importScripts('signalr.js');

const signalR = require("@microsoft/signalr");
const config = require('../config').default;

let connection = new signalR.HubConnectionBuilder()
    .withUrl(`${config.apiUrl}/hub/notifications`)
    .build();

// TODO change method name
connection.on("ReceiveNotification", (...all) => {
    console.log(all);
});

// TODO subscribe to broadcast/direct notifications

connection.start();
    // .then(() => connection.invoke("send", "Hello"));

self.addEventListener(
    "message",
    function(e) {
        self.postMessage(e.data);
    },
    false
);