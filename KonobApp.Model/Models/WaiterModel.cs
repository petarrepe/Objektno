using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonobApp.Model.Models
{
    [Serializable]
    public class WaiterModel
    {
        [Key]
        public virtual int IDWaiter { get; set; }
        public virtual int IDCaffe { get; set; }
        [Display(Name = "Ime")]
        public virtual string Name { get; set; }
        [Display(Name = "Prezime")]
        public virtual string Surname { get; set; }
        [Display(Name = "Korisničko ime")]
        public virtual string Username { get; set; }
        [Display(Name = "Lozinka")]
        public virtual string Password { get; set; }

        public virtual IList<ReceiptModel> Receipts { get; set; }
        public virtual CaffeModel Caffe { get; set; }
        public virtual string GetFullName()
        {
            return Name + " " + Surname;
        }
    }
}
