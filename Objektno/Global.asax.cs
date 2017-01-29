using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Objektno
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer<DbContext>(null);

            //Added so the App can find Views in Admin folder
            ViewEngines.Engines.Clear();

            ExtendedRazorViewEngine engine = new ExtendedRazorViewEngine();
            engine.AddViewLocationFormat("~/Views/Admin/{1}/{0}.cshtml");
            engine.AddViewLocationFormat("~/Views/Admin/{1}/{0}.vbhtml");

            // Add a shared location too, as the lines above are controller specific
            engine.AddPartialViewLocationFormat("~/Views/Admin/{0}.cshtml");
            engine.AddPartialViewLocationFormat("~/Views/Admin/{0}.vbhtml");

            ViewEngines.Engines.Add(engine);
        }
    }

    public class ExtendedRazorViewEngine : RazorViewEngine
    {
        public void AddViewLocationFormat(string paths)
        {
            List<string> existingPaths = new List<string>(ViewLocationFormats);
            existingPaths.Add(paths);

            ViewLocationFormats = existingPaths.ToArray();
        }

        public void AddPartialViewLocationFormat(string paths)
        {
            List<string> existingPaths = new List<string>(PartialViewLocationFormats);
            existingPaths.Add(paths);

            PartialViewLocationFormats = existingPaths.ToArray();
        }
    }
}
