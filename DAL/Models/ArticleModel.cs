using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class ArticleModel : AbstractModel
    {
        protected internal override int _id { get { return IDArticle; } set { _id = IDArticle; } }

        [Key]
        public virtual int IDArticle { get; set; }
        public virtual string Name { get; set; }
        public virtual float Price { get; set; } //trebat ce se prilagoditi tipu SmallMoney

        public virtual IList<ArticleReceiptModel> ArtRec { get; set; }
        public virtual IList<ArticleInCaffeModel> ArtCaf { get; set; }
    }
}