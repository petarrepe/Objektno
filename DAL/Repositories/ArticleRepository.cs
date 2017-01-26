using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonobApp.Model.Repositories;
using KonobApp.Model.Models;
using NHibernate;
using KonobApp.Interfaces;

namespace DAL.Repositories
{
    class ArticleRepository : Subject, IArticleRepository
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

        }

        public void LoadArticle()
        {

        }

        public void LoadCategory()
        {

        }

        public void AddArticle(string name, float price, int categoryID)
        {

        }

        public void UpdateArticle(int articleID, string name, float price, int categoryID)
        {

        }

        public void DeleteArticle(int articleID)
        {

        }

        public ArticleModel FindArticleByID(int ID)
        {
            return null;
        }

        public ArticleModel FindArticleByName(string name)
        {
            return null;
        }

        public ArticleModel FindArticleByCategory(int categoryID)
        {
            return null;
        }
    }
}
