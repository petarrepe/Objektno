using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Objektno.Models
{
    public class ArticleModel
    {
        public virtual int IDArticle { get; set; }
        public virtual string Name { get; set; }
        public virtual float Price { get; set; } //trebat ce se prilagoditi tipu SmallMoney

        public virtual IList<ArticleReceiptModel> ArtRec { get; set; }
        public virtual IList<ArticleInCaffeModel> ArtCaf { get; set; }
    }
}