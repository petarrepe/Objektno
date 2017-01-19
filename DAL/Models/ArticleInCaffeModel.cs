using System.ComponentModel.DataAnnotations;

namespace DAL.Models
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