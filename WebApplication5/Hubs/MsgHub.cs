using Microsoft.AspNetCore.SignalR;

namespace WebSignalR.Hubs
{
    public class MsgHub:Hub
    {
        //create send  msg to all users connect to server
        public async void SendMsg(string user,string msg )
        {
            //"ReceiveMsg" : function name in js file
            await Clients.All.SendAsync("ReceiveMsg", user, msg );
        }
    }
}
