using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Objektno.Models
{
    public class UserModel
    {
        public virtual int IDUser { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string CardNumber { get; set; } //NULLABLE

        public virtual IList<ReceiptModel> Receipts { get; set; }

    }
}