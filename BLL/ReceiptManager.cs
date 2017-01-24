using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class ReceiptManager
    {
        /// <summary>
        /// Šalje notifikaciju konobaru tj. na desktop aplikaciju
        /// </summary>
        internal static void SendReceipt(Receipt receipt)
        {
            NotificationService.Facade.Send(receipt.ToJson());
        }
    }
}
