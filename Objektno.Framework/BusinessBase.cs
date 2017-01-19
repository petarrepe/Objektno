using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objektno.Framework
{
    public abstract class BusinessBase :
        INotifyPropertyChanged,
        IEditableObject,
        IDataErrorInfo,
        IBusinessObject
    {
        #region Constructor, LazyLoad & CreateNew

        private Func<int, IDTOObject> loadFunction;
        protected void CheckLazyLoad()
        {
            if (State == BusinessObjectState.NotLoaded)
            {
                int i = parent.IndexOf(this);
                var dtoObject = loadFunction(i);
                Load(dtoObject);
            }
        }

        protected BusinessBase()
        {
            state = BusinessObjectState.New;
        }

        protected BusinessBase(Func<int, IDTOObject> loadFunction)
        {
            state = BusinessObjectState.NotLoaded;
            this.loadFunction = loadFunction;
        }

        public static BO CreateNew<BO>(IDTOObject dto) where BO : IBusinessObject, new()
        {
            BO item = new BO();
            item.Load(dto);
            return item;
        }

        #endregion

        #region IDataErrorInfo

        private Dictionary<string, string> errors = new Dictionary<string, string>();

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error
        {
            get
            {
                StringBuilder res = new StringBuilder();
                foreach(KeyValuePair<string, string> e in errors)
                {
                    if (!string.IsNullOrEmpty(e.Value))
                        res.AppendLine(e.Key + ":" + e.Value);
                }

                return res.ToString();
            }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                if (errors.ContainsKey(columnName))
                    return errors[columnName];

                return string.Empty;
            }
        }

        #endregion

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region EditableObject

        private bool inEdit = false;

        [Browsable(false)]
        public bool InEdit
        {
            get { return inEdit; }
        }

        #region IEditableObject Members

        void IEditableObject.BeginEdit()
        {
            if (!InEditMode)
            {
                return;
            }
            if (!inEdit)
            {
                Backup();
                inEdit = true;
            }
        }

        void IEditableObject.CancelEdit()
        {
            if (!InEditMode)
                return;
            if (inEdit)
            {
                Restore();
                inEdit = false;
            }
        }

        void IEditableObject.EndEdit()
        {
            if (!InEditMode)
                return;

            if (inEdit)
            {
                inEdit = false;
            }
        }

        #endregion

        #region Backup / Restore

        protected BusinessBase backupObject;

        private void Backup()
        {
            if (backupObject == null)
            {
                backupObject = (BusinessBase)Activator.CreateInstance(this.GetType());

                DoBackup();

                backupObject.state = state;
            }
        }

        private void Restore()
        {
            if (backupObject != null)
            {
                state = backupObject.state;

                DoRestore();

                Validate();

                OnPropertyChanged(string.Empty);
            }
        }

        protected virtual void DoBackup()
        {
            backupObject = (BusinessBase)this.MemberwiseClone();
        }

        protected abstract void DoRestore();

        #endregion

        #endregion

        #region IBusinessObject implementation

        #region IsDirty

        private bool isDirty;
        [Browsable(false)]
        public virtual bool IsDirty
        {
            get { return isDirty; }
        }

        #endregion

        #region State

        private BusinessObjectState state = BusinessObjectState.New;

        public BusinessObjectState State
        {
            get { return state; }
        }

        #endregion

        #region Load / ToDtoObject

        public void Load(IDTOObject dtoObject)
        {
            DoLoad(dtoObject);
            SetState(BusinessObjectState.Unmodified);
        }

        public abstract IDTOObject ToDtoObject();

        #endregion

        #region Delete

        public void Delete()
        {
            SetState(BusinessObjectState.Deleted);
            isDirty = true;
        }

        #endregion

        #region Edit

        public void Edit()
        {
            if (State != BusinessObjectState.New)
            {
                SetState(BusinessObjectState.Modified);
            }
            (this as IEditableObject).BeginEdit();
            AfterEdit();
        }

        #endregion

        #region CancelChanges

        public void CancelChanges()
        {
            if (State != BusinessObjectState.New)
            {
                Restore();
                SetState(BusinessObjectState.Unmodified);
            }
            else
            {
                if (parent != null)
                {
                    parent.Remove(this);
                    parent = null;
                }
            }

            AfterCancelChanges();
        }

        #endregion

        #region AcceptChanges

        public void AcceptChanges()
        {
            (this as IEditableObject).EndEdit();
            SetState(BusinessObjectState.Unmodified);
            backupObject = null;
            AfterSaveChanges();
        }

        #endregion

        #region ClearErrors

        public void ClearErrors()
        {
            errors.Clear();
            OnPropertyChanged(string.Empty);
        }

        #endregion

        #region Validate

        public void Validate(string propertyName)
        {
            DoValidation(propertyName);
        }

        #endregion 

        #region SetParent

        protected IBusinessObjectList parent;

        public void SetParent(IBusinessObjectList parent)
        {
            this.parent = parent;
        }

        #endregion

        #region BLL Object

        public IBllProvider BllProvider { get; set; }

        #endregion

        #endregion

        #region Abstract methods

        public abstract void Validate();

        public abstract void DoLoad(IDTOObject dtoObject);

        #endregion

        #region Virtual methods

        protected virtual void AfterEdit()
        {

        }

        protected virtual void AfterCancelChanges()
        {

        }

        protected virtual void AfterStateChanged()
        {

        }

        protected virtual void AfterSaveChanges()
        {

        }

        #endregion

        #region Protected methods

        protected void SetState(BusinessObjectState newState)
        {
            if (state != newState)
            {
                state = newState;
                AfterStateChanged();
                OnPropertyChanged("State");
                OnPropertyChanged("InEditMode");
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void SetError(string propertyName, string errorMessage)
        {
            if (errors.ContainsKey(propertyName))
            {
                errors[propertyName] = errorMessage;
            }
            else
            {
                errors.Add(propertyName, errorMessage);
            }
        }

        public Dictionary<string, string> GetValidationErrors()
        {
            return errors;
        }
        protected void PropertyHasChanged(string propertyName)
        {
            isDirty = true;
            OnPropertyChanged(propertyName);

            DoValidation(propertyName);
        }

        protected void DoValidation(string propertyName)
        {
            if (BllProvider != null)
            {
                string error = string.Empty;
                try
                {
                    BllProvider.Validate(this, propertyName);
                } catch(Exception err)
                {
                    error = err.Message;
                }

                SetError(propertyName, error);
                OnPropertyChanged(propertyName);
            }
            else
            {
                // Potrebno implementirati ukoliko BLL sloj
                // nije dostupan.
            }
        }

        #endregion

        [Browsable(false)]
        public bool InEditMode
        {
            get { return State != BusinessObjectState.Unmodified; }
        }
    }
}
