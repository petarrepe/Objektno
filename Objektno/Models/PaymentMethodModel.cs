using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Objektno.Models
{
    public class PaymentMethodModel
    {
        public virtual int IDPaymentMethod { get; set; }
        public virtual string TypePaymentMethod { get; set; }

        public virtual IList<ReceiptModel> Receipts { get; set; }
    }
}