using Microsoft.AspNetCore.SignalR;

namespace WebSignalR.Hubs
{
    public class UsersOnlineHub:Hub
    {
        public static int UsersCounter=0;

        public void SendUsersCounter()
        {
            //send users online to all users
            Clients.All.SendAsync("GetUsersCounter",UsersCounter.ToString());
        }

        public override Task OnConnectedAsync()
        {
            //raise when user connect to site
            UsersCounter++;
            SendUsersCounter();
            //
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            //raise when user disconnect site
            UsersCounter--;
            SendUsersCounter();
            //
            return base.OnDisconnectedAsync(exception); 
        }
    }
}
