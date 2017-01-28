using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;


namespace NotificationsServer
{
    [HubName("NotificationsHub")]
    public class NotificationsHub : Hub
    {
        public void SendReceipt(KonobApp.Model.Models.ReceiptModel rcp)
        {
            Clients.All.ReceiveReceipt(rcp);
        }
    }
}