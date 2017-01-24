using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Caffe : AbstractModel
    {
        protected internal override int _id { get { return IDCaffe; } set { _id = IDCaffe; } }

        [Key]
        public virtual int IDCaffe { get; set; }
        public virtual string Name { get; set; }
        public virtual string Adress { get; set; }
        public virtual bool IsOpen { get; set; }

        public virtual IList<Table> Tables { get; set; }
        public virtual IList<Waiter> Waiters { get; set; }
        public virtual IList<ArticleInCaffe> ArticlesInCaffe { get; set; }
    }
}