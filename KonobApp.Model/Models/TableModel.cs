using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonobApp.Model.Models
{
    public class TableModel
    {
        [Key]
        public virtual int IDTable { get; set; }
        public virtual int IDCaffe { get; set; }
        public virtual bool IsOccupied { get; set; }

        public virtual CaffeModel Caffe { get; set; }
    }
}
