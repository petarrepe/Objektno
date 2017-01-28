using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace KonobApp.Controller
{
    /// <summary>
    /// Na van izlaže StartListening i StopListening za notifikacije.
    /// Nije potreban izričit poziv task.Dispose, ali je ostavljen zbog verbosity.
    /// </summary>
    class NotificationController
    {
        private Task listenForNotification;
        private bool isStarted;

        public NotificationController()
        {
        }

        ~NotificationController()
        {
            if (isStarted == true)
            {
                listenForNotification.Dispose();
            }
        }

        internal void StartListening()
        {
            if (isStarted == false)
            {
                listenForNotification = Task.Factory.StartNew(Listen);
                isStarted = true;
            }
        }
        internal void StopListening()
        {
            if (isStarted == true)
            {
                listenForNotification.Dispose();
                isStarted = false;
            }
        }

        private void Listen()
        {
            IHubProxy _hub;

            string url = @"http://localhost:8080/";
            var connection = new HubConnection(url);
            _hub = connection.CreateHubProxy("NotificationsHub");
            connection.Start().Wait();

            _hub.On("ReceiveReceipt", t=> RecieveReceipt(t));
            while (true)
            {
                Thread.Sleep(1000);
            }
        }

        private void RecieveReceipt(string t)
        {
            KonobApp.Model.Models.ReceiptModel reciept = JsonConvert.DeserializeObject<Model.Models.ReceiptModel>(t);
            //ovdje nešto radiš sa receptom kojeg si dobio 
        }
    }
}
