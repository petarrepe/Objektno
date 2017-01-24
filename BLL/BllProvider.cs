using DAL.Models;
using System.Collections.Generic;

namespace BLL
{
    public abstract class BllProvider:AbstractModel
    {
        public virtual bool isValid { get { return Validate(); } }
        protected virtual bool Validate()
        {
            return true;
        }
        public virtual void Save(BllProvider obj)
        {
            using (DAL.Facade facade = new DAL.Facade())
            {
                DAL.Models.AbstractModel model = GetDALModelObject();
                facade.Save(model);
            }
        }

        public virtual BllProvider Load(int id)
        {
            dynamic obj;

            using (DAL.Facade facade = new DAL.Facade())
            {
                obj = facade.FetchByAttributeValue<BllProvider>(t=>t._id==id);
            }
            return obj;

        }
        public virtual List<BllProvider> Load()
        {
            List<BllProvider> listOfObj;

            using (DAL.Facade facade = new DAL.Facade())
            {
                
                listOfObj = facade.FetchAll<BllProvider>();
            }
            return listOfObj;
        }

        protected abstract AbstractModel GetDALModelObject();
    }
}
