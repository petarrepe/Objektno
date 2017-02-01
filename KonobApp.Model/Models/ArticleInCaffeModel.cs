using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace KonobApp.Model.Models
{
    public class ArticleInCaffeModel
    {
        [Key]
        public virtual int ID { get; set; }
        public virtual int IDCaffe { get; set; }
        public virtual int IDArticle { get; set; }
        [Display(Name = "Dostupan")]
        public virtual bool IsAvailable { get; set; }

        public virtual CaffeModel Caffe { get; set; }
        public virtual ArticleModel Article { get; set; }
    }
}
