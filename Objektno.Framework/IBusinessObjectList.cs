using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objektno.Framework
{
    public interface IBusinessObjectList : IBindingList
    {
        IList GetChanges();
        void CancelChanges();
        void AcceptChanges();
        void SaveChanges(IBllProvider bllProvider);
    }
}
