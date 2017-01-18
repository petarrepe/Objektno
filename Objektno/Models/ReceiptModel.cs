using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Objektno.Models
{
    public class ReceiptModel
    {
        [Key]
        public virtual int IDReceipt { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual int IDWaiter { get; set; }
        public virtual int IDPaymentMethod { get; set; }
        public virtual int IDUser { get; set; } //NULLABLE
        public virtual float TotalCost { get; set; } //Trebat ce se pretvoriti u oblik tipa SmallMoney (00.000?)
        public virtual float Discount { get; set; } //NULLABLE

        public virtual IList<ArticleReceiptModel> ArtRec { get; set; }
        public virtual UserModel User { get; set; }
        public virtual WaiterModel Waiter { get; set; }
        public virtual PaymentMethodModel PaymentMethod { get; set; }
    }
}