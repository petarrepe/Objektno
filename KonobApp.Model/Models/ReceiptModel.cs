using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonobApp.Model.Models
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
    //private int _idReceipt;
    //private DateTime _date;
    //private Waiter _waiter;
    //private User _user;
    //private PaymentMethod _paymentMethod;
        private double _total;
    //private double _discount;
        private IList<ArticleModel> _articles;

        public virtual IList<ArticleModel> Articles { get; set; }
    

    public virtual double SetTotal()
        {
            double result = 0.0;
            foreach(ArticleModel art in _articles)
            {
                result += art.Price;
            }
            result *= Discount;
            _total = result;

            return result;
        }
    }
}
