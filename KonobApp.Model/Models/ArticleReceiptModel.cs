using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonobApp.Model.Models
{
    public class ArticleReceiptModel
    {
        [Key]
        public virtual int ID { get; set; }
        public virtual int IDReceipt { get; set; }
        public virtual int IDArticle { get; set; }
        [Display(Name = "Količina")]
        public virtual int Quantity { get; set; }
        [Display(Name = "Cijena jednoga")]
        public virtual float PriceOfOne { get; set; } //prilagoditi typu SmallMoney

        public virtual ReceiptModel Receipt { get; set; }
        public virtual ArticleModel Article { get; set; }
    }
}
