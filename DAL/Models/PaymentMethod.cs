using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class PaymentMethod
    {
        [Key]
        public virtual int IDPaymentMethod { get; set; }
        public virtual string TypePaymentMethod { get; set; }

        public virtual IList<Receipt> Receipts { get; set; }
    }
}