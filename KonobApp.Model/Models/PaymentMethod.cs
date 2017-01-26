using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonobApp.Model
{
    public class PaymentMethod
    {
        private int _idPaymentMethod;
        private string _paymentMethodName;

        public int IdPaymentMethod { get { return _idPaymentMethod; } set { _idPaymentMethod = value; } }
        public string PaymentMethodName { get { return _paymentMethodName; } set { _paymentMethodName = value; } }
    }
}
