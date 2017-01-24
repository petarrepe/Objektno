using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Waiter
    {
        [Key]
        public virtual int IDWaiter { get; set; }
        public virtual int IDCaffe { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }

        public virtual IList<Receipt> Receipts { get; set; }
        public virtual Caffe Caffe { get; set; }
    }
}