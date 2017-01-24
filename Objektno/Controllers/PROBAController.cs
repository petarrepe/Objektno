using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.Factories;

namespace Objektno.Controllers
{
    //FIXME MVc projekt ne radi bez reference na DAL :(
    public class PROBAController : Controller
    {
        // GET: PROBA
        public ActionResult Index()
        {
            var bll = ReceiptFactory.GetReceipt();

            if (bll.isValid)
            {
            };

            var test = bll.Load();
            return View();
        }

    }
}
