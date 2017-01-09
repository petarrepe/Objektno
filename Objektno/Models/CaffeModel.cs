using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Objektno.Models
{
    public class CaffeModel
    {
        public virtual int IDCaffe { get; set; }
        public virtual string Name { get; set; }
        public virtual string Adress { get; set; }
        public virtual bool IsOpen { get; set; }

        public virtual IList<TableModel> Tables { get; set; }
        public virtual IList<WaiterModel> Waiters { get; set; }
        public virtual IList<ArticleInCaffeModel> ArticlesInCaffe { get; set; }
    }
}