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

        void AddArticle(string lal);

    }
}
