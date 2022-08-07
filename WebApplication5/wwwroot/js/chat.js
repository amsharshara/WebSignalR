//create client msg
"user strict";

var conn = new signalR.HubConnectionBuilder().withUrl("/MsgHub").build();

//start connection
conn.start().then(function () {

    console.log("start");

}).catch(
    function (err) {
        console.error(err.toString());
    }
);

//send msg to server
document.getElementById("btnSend").addEventListener("click", function (evt) {
    var user = document.getElementById("txtUser").value;
    var msg = document.getElementById("txtMsg").value;
    conn.invoke("SendMsg", user, msg).catch(function (err) {
        console.error(err.toString());
    });

}
    );
//receive msg from server
//write function name
conn.on("ReceiveMsg", function (user, msg) {
    var li = document.createElement("li");
    li.innerHTML = user + ":" + msg;
    document.getElementById("lstMsg").appendChild(li);
    console.log(user + ":" + msg);

});
