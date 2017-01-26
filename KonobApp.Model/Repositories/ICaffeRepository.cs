using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonobApp.Model.Models;


namespace KonobApp.Model.Repositories
{
    public interface ICaffeRepository
    {
        IList<TableModel> Tables { get; }
        IList<WaiterModel> Waiters { get; }
        IList<ArticleInCaffeModel> ArticlesInCaffe { get; }

        void LoadAll();
        void LoadCaffe();
        void LoadTables();
        void LoadWaiters();
        void LoadArticlesInCaffe();

        void AddCaffe(string name, string address, bool isOpen);
        void UpdateCaffe(int caffeID, string name, string address, bool isOpen);
        void DeleteCaffe(int caffeID);

        void AddArticleInCaffe(int articleID, int caffeID, bool isAvailabe);
    }
}
