using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    internal class Article
    {
        private string name;
        private float price;
        private ArticleCategory category;

        internal Article()
        {
        }
        internal Article(string name, float price, ArticleCategory category)
        {
            this.name = name;
            this.price = price;
            this.category = category;
        }

    }
}
