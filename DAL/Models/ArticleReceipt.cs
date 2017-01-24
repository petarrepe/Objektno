using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class ArticleReceipt
    {
        [Key]
        public virtual int ID { get; set; }
        public virtual int IDReceipt { get; set; }
        public virtual int IDArticle { get; set; }
        public virtual int Quantity { get; set; }
        public virtual float PriceOfOne { get; set; } //prilagoditi typu SmallMoney

        public virtual Receipt Receipt { get; set; }
        public virtual Article Article { get; set; }
    }
}