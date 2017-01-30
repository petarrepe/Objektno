using System.Collections.Generic;
using System.Linq;
using KonobApp.Model.Models;

namespace Objektno.Models
{
    public class ReceiptViewModel
    {
        public List<ArticleModel> articlesInCaffe;
        public IDictionary<int, string> categories = new Dictionary<int,string>();


        internal ReceiptViewModel(int id)
        {
            var caffeRepository = DAL.Repositories.CaffeRepository.GetInstance();

            articlesInCaffe = caffeRepository.ListAvailableArticlesInCaffe(id).ToList();
            var aviableCategoriesInCaffe = articlesInCaffe.Select(t => t.IDCategory).Distinct().ToList();

            using (DAL.Facade facade = new DAL.Facade())
            {
                var temp = facade.FetchAll<CategoryModel>();
                foreach(var value in temp)
                {
                    if (aviableCategoriesInCaffe.Contains(value.IDCategory))
                    {
                        categories.Add(new KeyValuePair<int, string>(value.IDCategory, value.Name));
                    }
                }
            }
        }

    }
}