using System.Collections.Generic;
using System.Linq;
using KonobApp.Model.Models;

namespace Objektno.Models
{
    public class ReceiptViewModel
    {
        private List<ArticleModel> articlesInCaffe;

        internal ReceiptViewModel(int id)
        {
            var caffeRepository = DAL.Repositories.CaffeRepository.GetInstance();

            articlesInCaffe = caffeRepository.ListArticlesInCaffe(id).ToList();
        }
    }
}