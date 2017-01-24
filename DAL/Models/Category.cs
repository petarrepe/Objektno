using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Category
    {
        [Key]
        public virtual int IDCategory { get; set; }
        public virtual string Name { get; set; }

        public virtual IList<Article> Articles { get; set; }
    }
}