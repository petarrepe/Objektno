using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Cfg;

namespace Objektno.Models
{
    public class OpenNHibertnateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            var configurationPath = HttpContext.Current.Server.MapPath
            (@"~\Models\NHibernate\hibernate.cfg.xml");
            configuration.Configure(configurationPath);

            var caffeConfigurationFile = HttpContext.Current.Server.MapPath
            (@"~\Models\NHibernate\Caffe.mapping.xml");
            configuration.AddFile(caffeConfigurationFile);
            var tableConfigurationFile = HttpContext.Current.Server.MapPath
            (@"~\Models\NHibernate\Table.mapping.xml");
            configuration.AddFile(tableConfigurationFile);
            var waiterConfigurationFile = HttpContext.Current.Server.MapPath
            (@"~\Models\NHibernate\Waiter.mapping.xml");
            configuration.AddFile(waiterConfigurationFile);
            var articleConfigurationFile = HttpContext.Current.Server.MapPath
            (@"~\Models\NHibernate\Article.mapping.xml");
            configuration.AddFile(articleConfigurationFile);
            var artcafConfigurationFile = HttpContext.Current.Server.MapPath
            (@"~\Models\NHibernate\ArticleInCaffe.mapping.xml");
            configuration.AddFile(artcafConfigurationFile);
            var artrecConfigurationFile = HttpContext.Current.Server.MapPath
            (@"~\Models\NHibernate\ArticleReceipt.mapping.xml");
            configuration.AddFile(artrecConfigurationFile);
            var paymentConfigurationFile = HttpContext.Current.Server.MapPath
            (@"~\Models\NHibernate\PaymentMethod.mapping.xml");
            configuration.AddFile(paymentConfigurationFile);
            var receiptConfigurationFile = HttpContext.Current.Server.MapPath
            (@"~\Models\NHibernate\Receipt.mapping.xml");
            configuration.AddFile(receiptConfigurationFile);
            var userConfigurationFile = HttpContext.Current.Server.MapPath
            (@"~\Models\NHibernate\User.mapping.xml");
            configuration.AddFile(userConfigurationFile);

            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}