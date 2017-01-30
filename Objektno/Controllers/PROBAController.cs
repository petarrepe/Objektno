using System.Web.Mvc;
using KonobApp.Model.Models;
using Objektno.Notifications;

namespace Objektno.Controllers
{
    public class PROBAController : Controller
    {

        // GET: PROBA
        public ActionResult Index()
        {
            using (DAL.Facade facade = new DAL.Facade())
            {
                ReceiptModel rc = new ReceiptModel()
                {
                    IDReceipt = 1,
                    IDPaymentMethod = 1,
                    IDUser = 1,
                    IDWaiter = 1,
                    Date = System.DateTime.Now,
                    TotalCost = 500,
                    Discount = 5
                };

                //var randomReciept = facade.FetchAll<ReceiptModel>().First();
                var caffe = facade.FetchAll<CaffeModel>();
                NotificationService.SendReciept(rc);
                
                return View(caffe);
            }

        }
    }
}