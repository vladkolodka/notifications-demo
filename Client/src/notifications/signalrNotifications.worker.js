// importScripts('signalr.js');

const signalR = require("@microsoft/signalr");
const config = require('../config').default;

let connection = new signalR.HubConnectionBuilder()
    .withUrl(`${config.apiUrl}/hub/notifications`)
    .build();

connection.on("ReceiveNotification", (...all) => {
    console.log(all);
});

connection.start();
    // .then(() => connection.invoke("send", "Hello"));

self.addEventListener(
    "message",
    function(e) {
        self.postMessage(e.data);
    },
    false
);