using System;
using System.Collections.Generic;
using DAL.Models;

namespace BLL
{
    /// <summary>
    /// PARTIAL CLASS?
    /// </summary>

    internal partial class Receipt : BllProvider
    {
        private List<Article> articles { get; set; }
        private BusinessPlace place { get; set; }
        private PaymentMethod paymentMethod { get; set; }

        internal Receipt()
        {
        }
        internal Receipt(List<Article> articles, BusinessPlace place, PaymentMethod method)
        {
            this.articles = articles;
            this.place = place;
            this.paymentMethod = method;
        }


        internal void AddArticle(Article article)
        {
            if (articles == null)
            {
                articles = new List<Article>() { article };
            }
            else
            {
                articles.Add(article);
            }
        }

        internal void RemoveArticle(Article article)
        {
            articles.Remove(article);
        }
        internal string ToJson()//fixme: nije dovoljno čisto
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        protected override AbstractModel GetDALModelObject()
        {
            DAL.Models.Receipt model = new DAL.Models.Receipt();


            return model;
        }
    }
}
