using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService
{
    public static class Facade
    {
        private static NotificationHub hub = new NotificationHub();

        /// <summary>
        /// TODO: deserijalizirati json, izvući naziv primatelja, poslati notification
        /// </summary>
        /// <param name="obj"></param>
        public static void Send(string obj)
        {
            //string destination = ;
            //GlobalHost.ConnectionManager.GetHubContext<NotificationHub>().Clients.(obj);
        }

        public static void Send(string message, string to)
        {

            //User receiver;
            //if (Users.TryGetValue(to, out receiver))
            //{

            //    User sender = GetUser(Context.User.Identity.Name);

            //    IEnumerable<string> allReceivers;
            //    lock (receiver.ConnectionIds)
            //    {
            //        lock (sender.ConnectionIds)
            //        {

            //            allReceivers = receiver.ConnectionIds.Concat(
            //                sender.ConnectionIds);
            //        }
            //    }

            //    foreach (var cid in allReceivers)
            //    {

            //        Clients.Client(cid).received(new
            //        {
            //            sender = sender.Name,
            //            message = message,
            //            isPrivate = true
            //        });
            //    }
            }
        }
    }
