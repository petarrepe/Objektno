using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories
{
    public interface IArticleRepository
    {
        ArticleModel Article { get; }
        CategoryModel Category { get; }

        void LoadAll();
        void LoadArticle();
        void LoadCategory();

        void AddArticle(string name, float price, int categoryID);
        void UpdateArticle(int articleID, string name, float price, int categoryID);
        void DeleteArticle(int articleID);

        ArticleModel FindArticleByID(int ID);
        ArticleModel FindArticleByName(string name);
        ArticleModel FindArticleByCategory(int categoryID);

    }
}
