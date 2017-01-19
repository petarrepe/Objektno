using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objektno.Framework
{
    class BusinessBaseList<T> : BindingList<T>, IBusinessObjectList where T : IBusinessObject, new()
    {
        #region Override Insert and Delete from BindingList

        #region Insert
        protected override void InsertItem(int index, T item)
        {
            item.SetParent(this);
            base.InsertItem(index, item);
        }
        #endregion

        #region Delete

        private List<T> deletedItems = new List<T>();

        protected override void RemoveItem(int index)
        {
            T item = this[index];
            if (item.State != BusinessObjectState.New)
            {
                item.Delete();
                deletedItems.Add(item);
            }
            base.RemoveItem(index);
        }

        #endregion

        #endregion

        public bool IsDirty
        {
            get
            {
                if (deletedItems.Count > 0)
                {
                    return true;
                }
                foreach( T item in this)
                {
                    if (item.IsDirty)
                        return true;
                }
                return false;
            }
        }

        #region IBusinessObjectList Members

        public void SaveChanges(IBllProvider bllProvider)
        {
            IList changes = GetChanges();
            bllProvider.SaveChanges(changes);
            AcceptChanges();
        }

        public void AcceptChanges()
        {
            foreach(T item in this.Where(t => t.State == BusinessObjectState.New || t.State == BusinessObjectState.Modified))
            {
                item.AcceptChanges();
            }
            deletedItems.Clear();
        }

        public void CancelChanges()
        {
            foreach(T item in this.Where(t => t.State != BusinessObjectState.NotLoaded && t.State != BusinessObjectState.Unmodified).ToList())
            {
                item.CancelChanges();
            }
            foreach(T item in deletedItems)
            {
                this.Add(item);
                item.CancelChanges();
            }
            deletedItems.Clear();
        }

        public IList GetChanges()
        {
            List<T> changes = new List<T>();
            foreach(T item in deletedItems)
            {
                changes.Add(item);
            }
            foreach(T item in this.Where(i => i.State != BusinessObjectState.NotLoaded))
            {
                if (item.IsDirty || item.State == BusinessObjectState.New)
                    changes.Add(item);
            }
            return changes;
        }

        #endregion

        public static BusinessBaseList<T> CreateNew(IEnumerable<IDTOObject> items)
        {
            BusinessBaseList<T> list = new BusinessBaseList<T>();
            foreach(var dto in items)
            {
                T businessObject = BusinessBase.CreateNew<T>(dto);
                list.Add(businessObject);
            }
            return list;
        }
    }
}
