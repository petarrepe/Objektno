using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// TODO : obrisati tablicu User iz baze podataka, prije toga treba otpustiti strani ključ
/// </summary>
namespace KonobApp.Model.Models
{
    [Serializable]
    public class UserModel
    {
        [Key]
        public virtual int IDUser { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string CardNumber { get; set; } //NULLABLE
        public virtual DateTime DateOfBirth { get; set; }
        public virtual bool IsAdmin { get; set; }

        public virtual IList<ReceiptModel> Receipts { get; set; }

    }
}
