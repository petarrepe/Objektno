﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Objektno.Models
{
    public class WaiterModel
    {
        public virtual int IDWaiter { get; set; }
        public virtual int IDCaffe { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }

        public virtual IList<ReceiptModel> Receipts { get; set; }
        public virtual CaffeModel Caffe { get; set; }
    }
}