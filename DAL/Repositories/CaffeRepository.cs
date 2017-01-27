﻿using System.Text;
using System.Threading.Tasks;
using KonobApp.Model.Repositories;
using KonobApp.Model.Models;
using NHibernate;
using KonobApp.Interfaces;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class CaffeRepository : Subject, ICaffeRepository
    {
        private static CaffeRepository _instance = null;
        private ISession nhibernateSession;

        private IList<TableModel> _tables = new List<TableModel>();
        private IList<WaiterModel> _waiters = new List<WaiterModel>();
        private IList<ArticleInCaffeModel> _artInCaf = new List<ArticleInCaffeModel>();
        private IList<ArticleModel> _articles = new List<ArticleModel>();
        private IList<CaffeModel> _caffes = new List<CaffeModel>();


        private CaffeModel _currCaffe;
        private TableModel _currTable;

        public IList<TableModel> Tables { get { return _tables; } }
        public IList<ArticleModel> Articles { get { return _articles; } }
        public IList<WaiterModel> Waiters { get { return _waiters; } }
        public IList<ArticleInCaffeModel> ArticlesInCaffe { get { return _artInCaf; } }
        public IList<CaffeModel> Caffes { get { return _caffes; } }

        public CaffeModel CurrentCaffe { get { return _currCaffe; } }
        public TableModel CurrentTable { get { return _currTable; } }

        private CaffeRepository()
        {

        }

        public static CaffeRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CaffeRepository();
            }

            return _instance;
        }

        #region Load

        public void LoadAll()
        {
            //zasada nepotrebno?
        }

        public void LoadCaffe() //da li previše toga stvaraš?
        {
            IList<ArticleInCaffeModel> artCafList = null;
            IList<WaiterModel> waitersCaffeList = null;
            IList<TableModel> tablesCaffeList = null;

            using (Facade facade = new Facade())
            {
                _caffes = facade.FetchAll<CaffeModel>();
                artCafList = facade.FetchAll<ArticleInCaffeModel>();
                waitersCaffeList = facade.FetchAll<WaiterModel>();
                tablesCaffeList = facade.FetchAll<TableModel>();
            }

            if (_articles == null) LoadArticles();
            if (_waiters == null) LoadWaiters();
            if (_tables == null) LoadTables();

            foreach (CaffeModel caffe in _caffes)
            {
                caffe.ArticlesInCaffe = artCafList.Where(t => t.IDCaffe == caffe.IDCaffe).ToList();
                foreach (ArticleInCaffeModel artCaf in caffe.ArticlesInCaffe)
                {
                    artCaf.Article = _articles.FirstOrDefault(t => t.IDArticle == artCaf.IDArticle);
                }

                caffe.Tables = tablesCaffeList.Where(t => t.IDCaffe == caffe.IDCaffe).ToList();
                caffe.Waiters = waitersCaffeList.Where(t => t.IDCaffe == caffe.IDCaffe).ToList();
            }
        }

        public void LoadTables()
        {
            using (ISession nhibernateSession = OpenNHibernateSession.OpenSession())
            {
                IQuery query = nhibernateSession.CreateQuery("from Table");
                _tables = query.List<TableModel>();
            }
        }

        public void LoadWaiters()
        {
            using (ISession nhibernateSession = OpenNHibernateSession.OpenSession())
            {
                IQuery query = nhibernateSession.CreateQuery("from Waiter");
                _waiters = query.List<WaiterModel>();
            }
        }

        public void LoadArticlesInCaffe()
        {
            using (ISession nhibernateSession = OpenNHibernateSession.OpenSession())
            {
                IQuery query = nhibernateSession.CreateQuery("from ArticleInCaffe");
                _artInCaf = query.List<ArticleInCaffeModel>();
            }
        }

        public void LoadArticles()
        {
            using (ISession nhibernateSession = OpenNHibernateSession.OpenSession())
            {
                IQuery query = nhibernateSession.CreateQuery("from Article");
                _articles = query.List<ArticleModel>();
            }
        }
        #endregion

        #region CRUD

        public void AddCaffe(string name, string address, bool isOpen)
        {
            CaffeModel caffe = new CaffeModel();

            caffe.Name = name;
            caffe.Adress = address;
            caffe.IsOpen = isOpen;

            using (ISession session = OpenNHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(caffe);
                    transaction.Commit();
                }
            }

            _caffes.Add(caffe);
            NotifyObservers();
        }

        public void UpdateCaffe(int caffeID, string name, string address, bool isOpen)
        {
            CaffeModel caffe = FindCaffeByID(caffeID);

            caffe.Name = name;
            caffe.Adress = address;
            caffe.IsOpen = isOpen;

            using (ISession session = OpenNHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(caffe);
                    transaction.Commit();
                }
            }

            NotifyObservers();
        }

        public void DeleteCaffe(int caffeID)
        {
            CaffeModel caffe = FindCaffeByID(caffeID);

            using (ISession session = OpenNHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(caffe);
                    transaction.Commit();
                }
            }

            _caffes.Remove(caffe);
            NotifyObservers();
        }

        public void AddArticleInCaffe(int articleID, int caffeID)
        {
            ArticleInCaffeModel artCaf = new ArticleInCaffeModel();

            artCaf.IDArticle = articleID;
            artCaf.IDCaffe = caffeID;
            artCaf.IsAvailable = true;

            using (ISession session = OpenNHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(artCaf);
                    transaction.Commit();
                }
            }

            _artInCaf.Add(artCaf);
            NotifyObservers();
        }

        public void UpdateArticleInCaffe(int ID, bool IsAvailable)
        {
            ArticleInCaffeModel artCaf = FindArtInCaffByID(ID);

            artCaf.IsAvailable = IsAvailable;

            using (ISession session = OpenNHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(artCaf);
                    transaction.Commit();
                }
            }

            NotifyObservers();
        }
        public void DeleteArticleInCaffe(int ID)
        {
            ArticleInCaffeModel artCaf = FindArtInCaffByID(ID);

            using (ISession session = OpenNHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(artCaf);
                    transaction.Commit();
                }
            }

            _artInCaf.Remove(artCaf);
            NotifyObservers();
        }

        public void AddTable(int caffeID)
        {
            TableModel table = new TableModel();

            table.IDCaffe = caffeID;
            table.IsOccupied = false;

            using (ISession session = OpenNHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(table);
                    transaction.Commit();
                }
            }

            _tables.Add(table);
            NotifyObservers();
        }
        public void UpdateTable(int tableID, int caffeID, bool IsOccupied)
        {
            TableModel table = FindTableByID(tableID);

            table.IDCaffe = caffeID;
            table.IsOccupied = IsOccupied;

            using (ISession session = OpenNHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(table);
                    transaction.Commit();
                }
            }

            NotifyObservers();
        }
        public void DeleteTable(int tableID)
        {
            TableModel table = FindTableByID(tableID);

            using (ISession session = OpenNHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(table);
                    transaction.Commit();
                }
            }

            _tables.Remove(table);
            NotifyObservers();
        }
        #endregion

        public IList<ArticleModel> ListArticlesInCaffe(int caffeID)
        {
            List<ArticleModel> articlesCaffe = new List<ArticleModel>();
            foreach (ArticleInCaffeModel artCaf in _artInCaf)
            {
                if (artCaf.IDCaffe == caffeID)
                {
                    articlesCaffe.Add(artCaf.Article);
                }
            }

            return articlesCaffe;
        }

        public IList<TableModel> ListAllTablesInCaffe(int caffeID)
        {
            return Tables.Where(t => t.IDCaffe == caffeID).ToList();
        }

        public IList<TableModel> ListFreeTablesInCaffe(int caffeID)
        {
            return Tables.Where(t => t.IDCaffe == caffeID).Where(t => t.IsOccupied == false).ToList();
        }

        public CaffeModel FindCaffeByID(int caffeID)
        {
            return Caffes.Where(c => c.IDCaffe == caffeID).First();
        }

        public CaffeModel FindCaffeByName(string name)
        {
            return Caffes.Where(c => c.Name == name).First();
        }

        public CaffeModel FindCaffeByAddress(string address)
        {
            return Caffes.Where(c => c.Adress == address).First();
        }

        public ArticleInCaffeModel FindArtInCaffByID(int ID)
        {
            return ArticlesInCaffe.Where(a => a.ID == ID).First();
        }

        public TableModel FindTableByID(int tableID)
        {
            return Tables.Where(t => t.IDTable == tableID).First();
        }
    }
}
