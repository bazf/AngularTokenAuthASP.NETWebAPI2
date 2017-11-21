namespace WEB.Controllers
{
    using BLL.Interfaces.IBLs;
    using Core.DTOs.UserDTOs;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;

    [Authorize(Roles = "admin"), RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private IUserBL userBL;

        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }

        [HttpGet, Route("all")]
        public async Task<List<UserDTO>> GetAll()
        {
            return await userBL.GetAllAsync();
        }

    }
}
