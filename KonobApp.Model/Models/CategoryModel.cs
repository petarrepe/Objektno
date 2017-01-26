using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonobApp.Model.Models
{
    public class CategoryModel
    {
        [Key]
        public virtual int IDCategory { get; set; }
        public virtual string Name { get; set; }

        public virtual IList<ArticleModel> Articles { get; set; }
    }
}
