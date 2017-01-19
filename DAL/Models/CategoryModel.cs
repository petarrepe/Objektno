using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class CategoryModel
    {
        [Key]
        public virtual int IDCategory { get; set; }
        public virtual string Name { get; set; }

        public virtual IList<ArticleModel> Articles { get; set; }
    }
}