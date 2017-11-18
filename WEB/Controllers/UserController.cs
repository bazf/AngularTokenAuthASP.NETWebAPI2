namespace WEB.Controllers
{
    using BLL.Interfaces.IBLs;
    using System.Web.Http;

    [RoutePrefix("user")]
    public class UserController : ApiController
    {
        private IUserBL userBL;

        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(userBL.GetAll());

            //return Json(productBL.GetAllProducts());
        }

    }
}
