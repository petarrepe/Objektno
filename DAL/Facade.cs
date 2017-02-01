using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;
using NHibernate;
using System;

namespace DAL
{
    public class Facade : IDisposable
    {
        private ISession _session;

        public Facade()
        {
            _session = OpenNHibernateSession.OpenSession();
            _session.Transaction.Begin();
        }


        public List<T> FetchAll<T>() where T : class // : BuisnessClass
        {
            List<T> retrievedObjects = _session.Query<T>().ToList();

            return retrievedObjects;
        }

        public List<T> FetchFromPosition<T>(int position, int count) where T : class // : BuisnessClass
        {
            List<T> retrievedObjects = _session.Query<T>().Skip(position).Take(count).ToList();

            return retrievedObjects;
        }

        //public bool Exists<T>(int id) where T : class //bll
        //{
        //    var itemExists = _session.Query<T>().Where(t => t.id == id).First();

        //    return (itemExists != null) ? true : false;
        //}

        public uint ItemsCount<T>() where T : class //bll
        {
            uint count = (uint) _session.Query<T>().Count();

            return count;
        }
        public void Insert<T>(T obj)
        {

                _session.Save(obj);


            
        }

        public void InsertReceipt<T>(T obj)
        {
            try
            {
                _session.CreateSQLQuery("SET IDENTITY_INSERT receipt ON").UniqueResult();
                _session.Save(obj);

            }
            catch (Exception exc)
            {
                // If the object as a null identifier everything else fails. Remove from context
                if (_session.GetIdentifier(this) == null)
                {
                    _session.Close();
                    _session.Dispose();
                    throw;
                }
            }

        }
        public void Insert<T>(List<T> obj)
        {
            for (int i = 0; i < obj.Count; i++)
            {
                _session.Save(obj);
            }
        }
        public void Delete<T>(T obj)
        {
            _session.Delete(obj);
        }

        public void Update<T>(T obj)
        {
            _session.Update(obj);
        }

        public void Dispose()
        {
            _session.Transaction.Commit();
            _session.Close();
        }
    }
}