﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonobApp.Model.Models;

namespace KonobApp.Model.Repositories
{
    public interface IArticleRepository
    {
        ArticleModel CurrentArticle { get; }
        CategoryModel Category { get; }

        void LoadAll();
        void LoadArticle();
        void LoadCategory();

        void AddArticle(string name, float price, int categoryID);
        void UpdateArticle(int articleID, string name, float price, int categoryID);
        void DeleteArticle(int articleID);

        ArticleModel FindArticleByID(int ID);
        ArticleModel FindArticleByName(string name);
        IList<ArticleModel> FindArticlesByCategory(int categoryID);
        CategoryModel FindCategoryByID(int categoryID);

    }
}