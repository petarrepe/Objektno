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
        void LoadArticles();

        void AddCaffe(string name, string address, bool isOpen);
        void UpdateCaffe(int caffeID, string name, string address, bool isOpen);
        void DeleteCaffe(int caffeID);

        void AddArticleInCaffe(int articleID, int caffeID);
        void UpdateArticleInCaffe(int ID, bool IsAvailable);
        void DeleteArticleInCaffe(int ID);

        void AddTable(int caffeID);
        void UpdateTable(int tableID, int caffeID, bool IsOccupied);
        void DeleteTable(int tableID);
        
        IList<ArticleModel> ListArticlesInCaffe(int caffeID);
        IList<TableModel> ListAllTablesInCaffe(int caffeID);
        IList<TableModel> ListFreeTablesInCaffe(int caffeID);
        CaffeModel FindCaffeByID(int caffeID);
        CaffeModel FindCaffeByName(string name);
        CaffeModel FindCaffeByAddress(string address);
        ArticleInCaffeModel FindArtInCaffByID(int ID);
        TableModel FindTableByID(int tableID);
    }
}
