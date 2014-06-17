using System.Web.Mvc;
using DiplomMVC.Areas.Default.Models.Home;

namespace DiplomMVC.Areas.Default.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Default/Home/
        [HttpGet]
        public ActionResult Index()
        {
            var model = new IndexModel
            {
                FirstName = "Alexander",
                LastName = "Belenkov"
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(IndexModel model)
        {
            var username = model.UserName;
            return View(model);
        }
    }
}
