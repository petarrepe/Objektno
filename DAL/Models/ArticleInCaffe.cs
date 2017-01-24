using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class ArticleInCaffe
    {
        [Key]
        public virtual int ID { get; set; }
        public virtual int IDCaffe { get; set; }
        public virtual int IDArticle { get; set; }
        public virtual bool IsAvailable { get; set; }

        public virtual Caffe Caffe { get; set; }
        public virtual Article Article { get; set; }
    }
}