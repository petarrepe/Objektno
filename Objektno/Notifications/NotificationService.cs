using Microsoft.AspNet.SignalR.Client;

namespace Objektno.Notifications
{
    public static class NotificationService
    {

        internal static void SendReciept(KonobApp.Model.Models.ReceiptModel rcp)
        {
            int idCaffe; //FIXME : u budućnosti bi se po ovome trebao slati notification samo odredjenom kaficu; onom u kojem je napravljena narudžba

            IHubProxy _hub;
            string url = @"http://localhost:8080/";
            var connection = new HubConnection(url);
            _hub = connection.CreateHubProxy("NotificationsHub");

            connection.Start().Wait();

            _hub.Invoke("SendReceipt", rcp).Wait();
        }

    }
}