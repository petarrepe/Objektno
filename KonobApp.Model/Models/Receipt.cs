using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonobApp.Model.Models
{
    public class Receipt
    {
        private int _idReceipt;
        private DateTime _date;
        private Waiter _waiter;
        private User _user;
        private PaymentMethod _paymentMethod;
        private double _total;
        private double _discount;
        private IList<Article> _articles;


        public int IdReceipt { get { return _idReceipt; } set { _idReceipt = value; } }
        public DateTime Date { get { return _date; } set { _date = value; } }
        public Waiter Waiter { get { return _waiter; } set { _waiter = value; } }
        public User User { get { return _user; } set { _user = value; } }
        public PaymentMethod IdPaymentMethod { get { return _paymentMethod; } }
        public double Total { get { return _total; } set { _total = value; } }
        public double Discount { get { return _discount; } set { _discount = value; } }
        public IList<Article> Articles { get { return _articles; }  set { SetTotal(); _articles = value; } }

        public double SetTotal()
        {
            double result = 0.0;
            foreach(Article art in _articles)
            {
                result += art.Price;
            }
            result *= _discount;
            _total = result;

            return result;
        }
    }
}
