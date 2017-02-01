using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonobApp.Model.Models
{
    public class CaffeModel
    {
        [Key]
        public virtual int IDCaffe { get; set; }
        [Display(Name = "Naziv kafića")]
        public virtual string Name { get; set; }
        [Display(Name = "Adresa")]
        public virtual string Adress { get; set; }
        [Display(Name = "Otvoren")]
        public virtual bool IsOpen { get; set; }

        public virtual IList<TableModel> Tables { get; set; }
        public virtual IList<WaiterModel> Waiters { get; set; }
        public virtual IList<ArticleInCaffeModel> ArticlesInCaffe { get; set; }
    }
}
