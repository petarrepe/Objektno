using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Objektno.Models
{
    public class CategoryModel
    {
        public virtual int IDCategory { get; set; }
        public virtual string Name { get; set; }

        public virtual IList<ArticleModel> Articles { get; set; }
    }
}