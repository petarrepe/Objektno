using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public partial class Receipt : AbstractModel
    {
        protected internal override int _id { get { return IDReceipt; } set { _id = IDReceipt; } }
        [Key]
        public virtual int IDReceipt { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual int IDWaiter { get; set; }
        public virtual int IDPaymentMethod { get; set; }
        public virtual int IDUser { get; set; } //NULLABLE
        public virtual float TotalCost { get; set; } //Trebat ce se pretvoriti u oblik tipa SmallMoney (00.000?)
        public virtual float Discount { get; set; } //NULLABLE

        public virtual IList<ArticleReceipt> ArtRec { get; set; }
        public virtual User User { get; set; }
        public virtual Waiter Waiter { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
    }
}