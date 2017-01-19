using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class CaffeModel : AbstractModel
    {
        protected internal override int _id { get { return IDCaffe; } set { _id = IDCaffe; } }

        [Key]
        public virtual int IDCaffe { get; set; }
        public virtual string Name { get; set; }
        public virtual string Adress { get; set; }
        public virtual bool IsOpen { get; set; }

        public virtual IList<TableModel> Tables { get; set; }
        public virtual IList<WaiterModel> Waiters { get; set; }
        public virtual IList<ArticleInCaffeModel> ArticlesInCaffe { get; set; }
    }
}