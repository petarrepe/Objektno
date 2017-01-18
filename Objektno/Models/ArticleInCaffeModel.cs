using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Objektno.Models
{
    public class ArticleInCaffeModel
    {
        [Key]
        public virtual int ID { get; set; }
        public virtual int IDCaffe { get; set; }
        public virtual int IDArticle { get; set; }
        public virtual bool IsAvailable { get; set; }

        public virtual CaffeModel Caffe { get; set; }
        public virtual ArticleModel Article { get; set; }
    }
}