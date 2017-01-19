using DAL.Models;
using System.Linq;
using System.Web.Mvc;

namespace Objektno.Controllers
{
    public class PROBAController : Controller
    {
        // GET: PROBA
        public ActionResult Index()
        {
            using (DAL.Facade facade = new DAL.Facade())
            {
                var employees = facade.FetchAll<CaffeModel>();
                return View(employees);
            }

        }
    }
}