using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonobApp.Model.Models
{
    public class ArticleModel
    {
        [Key]
        public virtual int IDArticle { get; set; }
        [Display(Name = "Naziv artikla")]
        public virtual string Name { get; set; }
        [Display(Name = "Cijena")]
        public virtual float Price { get; set; } //trebat ce se prilagoditi tipu SmallMoney
        public virtual int IDCategory { get; set; }

        public virtual CategoryModel Category { get; set; }
        public virtual IList<ArticleReceiptModel> ArtRec { get; set; }
        public virtual IList<ArticleInCaffeModel> ArtCaf { get; set; }
    }
}
