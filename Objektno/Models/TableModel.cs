using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Objektno.Models
{
    public class TableModel
    {
        public virtual int IDTable { get; set; }
        public virtual int IDCaffe { get; set; }
        public virtual bool IsOccupied { get; set; }

        public virtual CaffeModel Caffe { get; set; }
    }
}