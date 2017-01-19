using System.ComponentModel.DataAnnotations;

namespace DAL.Models
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