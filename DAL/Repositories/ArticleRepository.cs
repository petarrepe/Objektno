using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonobApp.Model.Repositories;
using KonobApp.Model.Models;
using NHibernate;
using KonobApp.Interfaces;
using System.ComponentModel;

namespace DAL.Repositories
{
    public class ArticleRepository : Subject, IArticleRepository
    {
        private static ArticleRepository _instance = null;
        private IList<ArticleModel> _articles = new List<ArticleModel>();
        private IList<CategoryModel> _categories = new List<CategoryModel>();
        private ArticleModel _currArticle;
        private CategoryModel _category;

        public IList<ArticleModel> Articles { get { return _articles; } }
        public IList<CategoryModel> Categories { get { return _categories; } }

        public CategoryModel Category { get { return _category; } }
        public ArticleModel CurrentArticle { get { return _currArticle; } }

        private ISession nhibernateSession;

        private ArticleRepository()
        {

        }

        public static ArticleRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ArticleRepository();
            }

            return _instance;
        }

        public void LoadAll()
        {
            LoadCategory();
            LoadArticle();
        }

        public void LoadArticle()
        {
            using (ISession nhibernateSession = OpenNHibernateSession.OpenSession())
            {
                IQuery query = nhibernateSession.CreateQuery("from ArticleModel");
                _articles = query.List<ArticleModel>();
            }
            if (_categories == null) LoadCategory();
            foreach (ArticleModel article in _articles)
            {
                article.Category = _categories.Where(c => c.IDCategory == article.IDCategory).First();
            }
        }

        public void LoadCategory()
        {
            using (ISession nhibernateSession = OpenNHibernateSession.OpenSession())
            {
                IQuery query = nhibernateSession.CreateQuery("from CategoryModel");
                _categories = query.List<CategoryModel>();
            }
        }

        public void AddArticle(string name, float price, int categoryID)
        {
            ArticleModel article = new ArticleModel();

            article.Category = FindCategoryByID(categoryID);
            article.IDCategory = categoryID;
            article.Price = price;
            article.Name = name;

            using (ISession session = OpenNHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(article);
                    transaction.Commit();
                }
            }

            _articles.Add(article);
            NotifyObservers();
        }

        public void UpdateArticle(int articleID, string name, float price, int categoryID)
        {
            ArticleModel article = FindArticleByID(articleID);

            article.Category = FindCategoryByID(categoryID);
            article.Name = name;
            article.Price = price;
            article.IDCategory = categoryID;

            using (ISession session = OpenNHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(article);
                    transaction.Commit();
                }
            }

            NotifyObservers();
        }

        public void DeleteArticle(int articleID)
        {
            ArticleModel article = FindArticleByID(articleID);

            using (ISession session = OpenNHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(article);
                    transaction.Commit();
                }
            }

            _articles.Remove(article);
            NotifyObservers();
        }

        public ArticleModel FindArticleByID(int ID)
        {
            return Articles.Where(a => a.IDArticle == ID).First();
        }

        public ArticleModel FindArticleByName(string name)
        {
            return Articles.Where(a => a.Name == name).First();
        }

        public IList<ArticleModel> FindArticlesByCategory(int categoryID)
        {
            return Articles.Where(a => a.IDCategory == categoryID).ToList();
        }

        public CategoryModel FindCategoryByID(int categoryID)
        {
            return Categories.Where(c => c.IDCategory == categoryID).First();
        }

        public BindingList<ArticleModel> GetArticlesBindingList()
        {
            LoadArticle();
            BindingList<ArticleModel> ArticlesBL = new BindingList<ArticleModel>(_articles);
            return ArticlesBL;
        }
    }
}
