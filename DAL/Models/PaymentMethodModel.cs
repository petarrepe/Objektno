using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class PaymentMethodModel
    {
        [Key]
        public virtual int IDPaymentMethod { get; set; }
        public virtual string TypePaymentMethod { get; set; }

        public virtual IList<ReceiptModel> Receipts { get; set; }
    }
}