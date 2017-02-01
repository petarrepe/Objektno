using System;
using System.Collections.Generic;
using System.Linq;
using KonobApp.Model.Models;

namespace Objektno.Models
{
    public class ReceiptViewModel
    {
        public List<ArticleModel> articlesInCaffe;
        public IDictionary<int, string> categories = new Dictionary<int,string>();
        public ReceiptModel receipt = new ReceiptModel();


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

            receipt.Articles= new List<ArticleModel>();
            receipt.ArtRec = new List<ArticleReceiptModel>();
        }

        /// <summary>
        /// Late night hotfix
        /// </summary>
        /// <param name="receipt"></param>
        internal void ProcessRecieptBeforeSending(ref ReceiptModel receipt)
        {
            receipt.Date = DateTime.Now;
            receipt.ArtRec = new List<ArticleReceiptModel>();
            receipt.Discount = 0;
            receipt.IDPaymentMethod = 1;
            receipt.IDUser = 1;
            receipt.IDWaiter = 1;
            receipt.TotalCost = (float)receipt.SetTotal();
        }

        internal void addArticle(int iDArticle)
        {
            var article = articlesInCaffe.Where(t => t.IDArticle == iDArticle).First();

            receipt.Articles.Add(article);
        }
    }
}