﻿using System;
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
        [Display(Name = "Ime")]
        public virtual string Name { get; set; }
        [Display(Name = "Prezime")]
        public virtual string Surname { get; set; }
        public virtual string Email { get; set; }
        [Display(Name = "Lozinka")]
        public virtual string Password { get; set; }
        [Display(Name = "Broj kartice")]
        public virtual string CardNumber { get; set; } //
        [Display(Name = "Datum rođenja")]
        public virtual DateTime DateOfBirth { get; set; }
        [Display(Name = "Admin")]
        public virtual bool IsAdmin { get; set; }

        public virtual IList<ReceiptModel> Receipts { get; set; }

        public virtual string GetFullName()
        {
            return Name + " " + "Surname";
        }
    }
}
