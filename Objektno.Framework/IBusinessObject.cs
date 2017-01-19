using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objektno.Framework
{
    public interface IBusinessObject
    {
        bool IsDirty { get; }
        BusinessObjectState State { get; }
        bool InEdit { get; }

        void Load(IDTOObject dalRecord);
        IDTOObject ToDtoObject();

        void Delete();
        void Edit();

        void CancelChanges();
        void AcceptChanges();

        void ClearErrors();
        void Validate(string propertyName);

        void SetParent(IBusinessObjectList parent);
        IBllProvider BllProvider { get; set; }
    }
}
