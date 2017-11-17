namespace WEB.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToRoute("AngularRoute");
        }
    }
}
