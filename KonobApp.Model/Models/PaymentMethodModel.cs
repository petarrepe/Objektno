using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonobApp.Model.Models
{
    [Serializable]
    public class PaymentMethodModel
    {
        [Key]
        public virtual int IDPaymentMethod { get; set; }
        public virtual string TypePaymentMethod { get; set; }

        public virtual IList<ReceiptModel> Receipts { get; set; }

        //private int _idPaymentMethod;
        //private string _paymentMethodName;

        //public int IdPaymentMethod { get { return _idPaymentMethod; } set { _idPaymentMethod = value; } }
        //public string PaymentMethodName { get { return _paymentMethodName; } set { _paymentMethodName = value; } }
    }
}
