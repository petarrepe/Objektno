using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;

namespace DAL
{
    public class OpenNHibernateSession
    {
        private readonly static string mvcDir = AppDomain.CurrentDomain.BaseDirectory;
        private readonly static string localDir = SetLocalDir();
        private readonly static string nHibernateDir = localDir + @"Models\NHibernate";

        /// <summary>
        /// Dirty, but should work without problems
        /// </summary>
        /// <returns></returns>
        private static string SetLocalDir()
        {
            string pattern = @"KonobApp.DesktopInit\\bDAL\\";
            Regex rgx = new Regex(pattern);
            string temp = mvcDir.Remove(mvcDir.Length - 9, 9) + @"DAL\";
            string replacement = @"DAL\";

            temp = rgx.Replace(temp, replacement);

            return temp;
        }


        public static ISession OpenSession()
        {

            var configuration = new Configuration();
            var configurationPath = Path.Combine(nHibernateDir, @"hibernate.cfg.xml");
            configuration.Configure(configurationPath);

            var caffeConfigurationFile = Path.Combine(nHibernateDir, @"Caffe.mapping.xml");
            configuration.AddFile(caffeConfigurationFile);

            var tableConfigurationFile = Path.Combine(nHibernateDir, @"Table.mapping.xml");
            configuration.AddFile(tableConfigurationFile);

            var waiterConfigurationFile = Path.Combine(nHibernateDir, @"Waiter.mapping.xml");
            configuration.AddFile(waiterConfigurationFile);

            var articleConfigurationFile = Path.Combine(nHibernateDir, @"Article.mapping.xml");
            configuration.AddFile(articleConfigurationFile);

            var artcafConfigurationFile = Path.Combine(nHibernateDir, @"ArticleInCaffe.mapping.xml");
            configuration.AddFile(artcafConfigurationFile);

            var artrecConfigurationFile = Path.Combine(nHibernateDir, @"ArticleReceipt.mapping.xml");
            configuration.AddFile(artrecConfigurationFile);

            var paymentConfigurationFile = Path.Combine(nHibernateDir, @"PaymentMethod.mapping.xml");
            configuration.AddFile(paymentConfigurationFile);

            var receiptConfigurationFile = Path.Combine(nHibernateDir, @"Receipt.mapping.xml");
            configuration.AddFile(receiptConfigurationFile);

            var userConfigurationFile = Path.Combine(nHibernateDir, @"User.mapping.xml");
            configuration.AddFile(userConfigurationFile);

            var categoryConfigurationFile = Path.Combine(nHibernateDir, @"Category.mapping.xml");
            configuration.AddFile(categoryConfigurationFile);

            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}