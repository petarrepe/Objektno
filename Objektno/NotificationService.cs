using NotificationProvider;

namespace Objektno
{
    public static class NotificationService
    {
        

        internal static void SendReciept(KonobApp.Model.Models.ReceiptModel rcp)
        {
            int idCaffe;

            NotificationProvider.NotificationService.SendReciept(rcp);
        }

    }
}