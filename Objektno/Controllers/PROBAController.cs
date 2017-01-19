using DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Objektno.Controllers
{
    public class PROBAController : Controller
    {
        // GET: PROBA
        public ActionResult Index()
        {
            IList<DAL.Models.CaffeModel> employees = null;
            using (DAL.Facade facade = new DAL.Facade())
            {
                employees = facade.FetchAll<CaffeModel>();

                var existsNOT = facade.Exists<CaffeModel>(100);
                var exists = facade.Exists<CaffeModel>(1);

                CaffeModel tt = new CaffeModel();
                tt.Name = "Test";
                tt.Adress = "test";
                var test = facade.FetchByAttributeValue<CaffeModel>(t => t.IDCaffe == 1);
                
                facade.Insert(tt);
            }
            using (DAL.Facade facade = new DAL.Facade())
            {
                employees = facade.FetchAll<CaffeModel>();
                facade.Delete(employees[1]);
            }
            return View(employees);
        }

    }
}
