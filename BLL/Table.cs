using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    internal class Table
    {
        //private int id; razmisliti
        private bool isTaken { get; set; }

        internal bool IsTableTaken()
        {
            return isTaken;
        }
        internal void Take()
        {
            isTaken = true;
        }
        internal void Free()
        {
            isTaken = false;
        }
    }
}
