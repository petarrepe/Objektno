using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Objektno.Models;

namespace Objektno.Controllers
{
    public class ReceiptController : Controller
    {
        private  static ReceiptViewModel viewModel;
        public ActionResult Create(int? IDCaffe)
        {
            viewModel = new ReceiptViewModel((int)IDCaffe);

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(int? IDArticle, int? quantity)
        {
            viewModel.addArticle((int)IDArticle);
            return View(viewModel);
        }

        public ActionResult SendReceipt()
        {
            viewModel.ProcessRecieptBeforeSending(ref viewModel.receipt);

            Notifications.NotificationService.SendReciept(viewModel.receipt);

            return View();
        }
    }
}