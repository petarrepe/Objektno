using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;
using NHibernate;
using System;
using System.Linq.Expressions;
using DAL.Models;

namespace DAL
{
    public class Facade : IDisposable
    {
        private ISession _session;

        public Facade()
        {
            _session = OpenNHibernateSession.OpenSession();
            _session.BeginTransaction();
        }


        public List<T> FetchAll<T>() where T : AbstractModel // : BuisnessClass
        {
            List<T> retrievedObjects = _session.Query<T>().ToList();

            return retrievedObjects;
        }

        public List<T> FetchFromPosition<T>(int position, int count) where T : AbstractModel // : BuisnessClass
        {
            List<T> retrievedObjects = _session.Query<T>().Skip(position).Take(count).ToList();

            return retrievedObjects;
        }

        public dynamic FetchByAttributeValue<T>(Expression<Func<T, bool>> whereFilter) where T : AbstractModel // : BuisnessClass
        {
            IList<T> retrievedObjects = _session.QueryOver<T>().Where(whereFilter).List<T>();

            return  retrievedObjects.ToList();
        }

        public bool Exists<T>(int id) where T : AbstractModel
        {
            var itemExists = _session.QueryOver<T>().List<T>().Where(t => t._id == id);
  
            return (itemExists.Count() != 0) ? true : false;
        }

        public void Insert(AbstractModel obj)
        {
            _session.Save(obj);
        }

        public void Insert(List<AbstractModel> obj)
        {
            for (int i = 0; i < obj.Count; i++)
            {
                _session.Save(obj);
            }
        }

        public void Update(List<AbstractModel> obj)
        {
            for (int i = 0; i < obj.Count; i++)
            {
                _session.Update(obj);
            }
        }

        public void Save(AbstractModel obj)
        {
                _session.SaveOrUpdate(obj);
        }

        public void Update(AbstractModel obj)
        {
                _session.Update(obj);
        }

        /// <summary>
        ///  FIXME: Delete ne radi kako treba zbog (pretpostavljam) toga što je tablica "Tables" prazna (u bazi).
        ///  Trebalo bi na SQL Profileru vidjeti kakav upit se generira u donje dvije metode.
        /// </summary>
        /// <param name="obj"></param>
        public void Delete(AbstractModel obj)
        {
            _session.Delete(obj);
        }

        public void Delete(List<AbstractModel> obj)
        {
            for (int i = 0; i < obj.Count; i++)
            {
                _session.Delete(obj);
            }
        }

        public uint ItemsCount<T>() where T : AbstractModel //bll
        {
            uint count = (uint) _session.Query<T>().Count();

            return count;
        }

        public void Dispose()
        {
            _session.Transaction.Commit();
            _session.Close();
        }
    }
}