using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp;

namespace NotificationProvider
{
    public class NotificationService
    {

        public static void SendReciept(KonobApp.Model.Models.ReceiptModel reciept)
        {
            NotificationMessage msg = new NotificationMessage(reciept);

            //test, radi ok
            //var test = ToByteArray(msg);
            //var testorig = FromByteArray<NotificationMessage>(test);

            using (var ws = new WebSocket("ws://localhost:4649"))//ws://echo.websocket.org
            {

                ws.OnOpen += (sender, e) => ws.SendAsync(ToByteArray(msg), null);

                ws.ConnectAsync();
            }
        }


        //privaete sdposfpof = StartListeningOnNotifaction);
        public static Task StartListeningOnNotification()
        {
            return Task.Factory.StartNew(ClientStart);
        }

        private static void ClientStart()
        {

            var ws = new WebSocket("ws://localhost:4649");
            ws.OnMessage += Ws_OnServerMessage;



            ws.ConnectAsync();
            while (true) Thread.Sleep(1000);
        }

        private static void Ws_OnServerMessage(object sender, MessageEventArgs e)
        {
            var reciept = FromByteArray<KonobApp.Model.Models.ReceiptModel>(e.RawData);

           
        }

        private static byte[] ToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        private static T FromByteArray<T>(byte[] data)
        {
            if (data == null)
                return default(T);
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                return (T)obj;
            }
        }
    }
}