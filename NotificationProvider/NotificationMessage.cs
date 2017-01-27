using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NotificationProvider
{
    [Serializable]
    public class NotificationMessage
    {

        private KonobApp.Model.Models.ReceiptModel _reciept { get; set; }

        public NotificationMessage()
        {
        }

        public NotificationMessage(KonobApp.Model.Models.ReceiptModel reciept)
        {
            _reciept = reciept;
        }

        public override string ToString()
        {
            return string.Format(_reciept.ToString());
        }
    }
}
