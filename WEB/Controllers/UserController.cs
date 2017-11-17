namespace WEB.Controllers
{
    using BLL.Interfaces;
    using System.Web.Http;

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
