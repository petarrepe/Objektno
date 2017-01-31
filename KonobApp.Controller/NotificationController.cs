using KonobApp.Interfaces;
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
    class NotificationController : INotificationController
    {
        private IMainController _mainController;
        private Task _listenForNotification;
        private bool _isStarted;

        public bool IsStarted { get { return _isStarted; } }

        public NotificationController(IMainController mainController)
        {
            _mainController = mainController;
            _isStarted = false;
        }

        ~NotificationController()
        {
            if (_isStarted == true)
            {          
                _listenForNotification.Dispose();
            }
        }

        public void StartListening()
        {
            if (_isStarted == false)
            {
                _listenForNotification = Task.Factory.StartNew(Listen);
                _isStarted = true;
            }
        }

        public void StopListening()
        {
            if (_isStarted == true)
            {
                _isStarted = false;
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

            while (IsStarted==true)
            {
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// This method is called once a message is recieved.
        /// </summary>
        /// <param name="t">Message contents</param>
        private void RecieveReceipt(string t)
        {
            KonobApp.Model.Models.ReceiptModel receipt = JsonConvert.DeserializeObject<Model.Models.ReceiptModel>(t);
            
            _mainController.AddNewOrder(receipt);
        }
    }
}
