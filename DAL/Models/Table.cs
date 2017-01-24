using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Table
    {
        [Key]
        public virtual int IDTable { get; set; }
        public virtual int IDCaffe { get; set; }
        public virtual bool IsOccupied { get; set; }

        public virtual Caffe Caffe { get; set; }
    }
}