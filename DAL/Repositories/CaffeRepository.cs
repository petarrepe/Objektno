using System.Text;
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

        private IList<TableModel> _tables;
        private IList<WaiterModel> _waiters;
        private IList<ArticleInCaffeModel> _artInCaf = new List<ArticleInCaffeModel>();
        private IList<ArticleModel> _articles;
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
            LoadAll();
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
            LoadCaffe();
            LoadArticlesInCaffe();
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
                IQuery query = nhibernateSession.CreateQuery("from TableModel");
                _tables = query.List<TableModel>();
            }

            if (_caffes == null) LoadCaffe();

            foreach (TableModel table in _tables)
            {
                table.Caffe = _caffes.Where(c => c.IDCaffe == table.IDCaffe).First();
            }
        }

        public void LoadWaiters()
        {
            using (ISession nhibernateSession = OpenNHibernateSession.OpenSession())
            {
                IQuery query = nhibernateSession.CreateQuery("from WaiterModel");
                _waiters = query.List<WaiterModel>();
            }
            if (_caffes == null) LoadCaffe();

            foreach (WaiterModel waiter in _waiters)
            {
                waiter.Caffe = _caffes.Where(c => c.IDCaffe == waiter.IDCaffe).First();
            }
        }

        public void LoadArticlesInCaffe()
        {
            using (Facade facade = new Facade())
            {
                _artInCaf = facade.FetchAll<ArticleInCaffeModel>();
            }

            if (_articles == null) LoadArticles();

            foreach (ArticleInCaffeModel artCaf in _artInCaf)
            {
                artCaf.Article = _articles.Where(a => a.IDArticle == artCaf.IDArticle).First();
            }
        }

        public void LoadArticles()
        {
            using (ISession nhibernateSession = OpenNHibernateSession.OpenSession())
            {
                IQuery query = nhibernateSession.CreateQuery("from ArticleModel");
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

        public void UpdateListArtInCaff(IList<ArticleInCaffeModel> ListArtCaff)
        {
            for (int i = 0; i < ListArtCaff.Count(); i++)
            {
                ArticleInCaffeModel artCaf = FindArtInCaffByID(ListArtCaff[i].ID);

                if (ListArtCaff[i].IsAvailable != artCaf.IsAvailable)
                {
                    artCaf.IsAvailable = ListArtCaff[i].IsAvailable;

                    using (ISession session = OpenNHibernateSession.OpenSession())
                    {
                        using (ITransaction transaction = session.BeginTransaction())
                        {
                            session.Update(artCaf); //mislim da ce ovo raditi
                            transaction.Commit();
                        }
                    }

                    NotifyObservers();
                }
            }
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

        public IList<CaffeModel> ListOpenCaffesWithFreeTables()
        {
            List<CaffeModel> openCaffes = new List<CaffeModel>();
            var temp = new List<CaffeModel>(_caffes.Where(t => t.IsOpen == true));

            foreach (var caffe in temp)
            {
                if (caffe.Tables.Where(t => t.IsOccupied == false).Count() > 0)
                {
                    openCaffes.Add(caffe);
                }
            }
            return openCaffes;
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

        public WaiterModel FindWaiterByID(int waiterID)
        {
            return Waiters.Where(w => w.IDWaiter == waiterID).First();
        }
    }
}
