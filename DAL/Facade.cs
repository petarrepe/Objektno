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
        }


        public List<T> FetchAll<T>() where T : class // : BuisnessClass
        {
            List<T> retrievedObjects = _session.Query<T>().ToList(); ;

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

        public void Dispose()
        {
            _session.Close();
        }
    }
}