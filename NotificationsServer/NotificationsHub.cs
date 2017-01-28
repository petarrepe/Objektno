using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;


namespace NotificationsServer
{
    [HubName("NotificationsHub")]
    public class NotificationsHub : Hub
    {
        public void SendReceipt(string reciepeAsJson)
        {
            Clients.All.ReceiveReceipt(reciepeAsJson);
            System.Console.WriteLine("Recieved recipe");
        }
    }
}