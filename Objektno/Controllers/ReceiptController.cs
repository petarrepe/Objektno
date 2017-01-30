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
        public ActionResult Create(int caffeID)
        {
            var viewModel = new ReceiptViewModel(caffeID);

            return View(viewModel);
        }
    }
}