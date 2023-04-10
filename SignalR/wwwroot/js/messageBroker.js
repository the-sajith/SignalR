

const signalrConnection = new signalR.HubConnectionBuilder()
    .withUrl("/messageBroker")
    .build();


signalrConnection.start().then(() => {
    console.log("SignalR Hub Connected");
}).catch((err) => {
    console.error(err.toString());
});


let messageCount = 0;

signalrConnection.on("onMessageReceived", (eventMessage) => {

    messageCount++;
    const msgCount = document.getElementById("messageCount");
    msgCount.innerText = "Messages: " + messageCount.toString();
    const div = document.getElementById("messages");
    const ul = document.createElement("ul");
    const li = document.createElement("li");
    li.innerText = messageCount.toString();


    for (const property in eventMessage)
    {
        const newDiv = document.createElement("div");
        const newContent = document.createTextNode(`${property}: ${eventMessage[property]}`);
        newDiv.appendChild(newContent);
        li.appendChild(newDiv);

    }

    ul.appendChild(li);
    div.appendChild(ul);
    window.scrollTo(0, document.body.scrollHeight);
});