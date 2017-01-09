using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Objektno.Models
{
    public class ArticleReceiptModel
    {
        public virtual int ID { get; set; }
        public virtual int IDReceipt { get; set; }
        public virtual int IDArticle { get; set; }
        public virtual int Quantity { get; set; }
        public virtual float PriceOfOne { get; set; } //prilagoditi typu SmallMoney

        public virtual ReceiptModel Receipt { get; set; }
        public virtual ArticleModel Article { get; set; }
    }
}