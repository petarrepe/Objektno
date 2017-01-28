﻿using Microsoft.AspNet.SignalR.Client;
using System.Threading;
using System.Threading.Tasks;

namespace KonobApp.Controller
{
    class NotificationController
    {
        private Task listenForNotification;     

        public NotificationController()
        {
            listenForNotification = Task.Factory.StartNew(Listen);
        }

        private void Listen()
        {
            IHubProxy _hub;
            string url = @"http://localhost:8080/";
            var connection = new HubConnection(url);
            _hub = connection.CreateHubProxy("NotificationsHub");
            connection.Start().Wait();

            _hub.On("SendReceipt", t=> RecieveReceipt(t));
            while (true)
            {
                Thread.Sleep(1000);
            }
        }

        private void RecieveReceipt(KonobApp.Model.Models.ReceiptModel recipe)
        {
            //ovdje nešto radiš sa receptom kojeg si dobio 
        }
    }
}
