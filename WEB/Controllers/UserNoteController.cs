namespace WEB.Controllers
{
    using BLL.Interfaces.IBLs;
    using Core.DTOs.UserNoteDTOs;
    using System.Collections.Generic;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;

    [Authorize, RoutePrefix("api/note")]
    public class UserNoteController : ApiController
    {
        private IUserNoteBL userNoteBL;

        public UserNoteController(IUserNoteBL userNoteBL)
        {
            this.userNoteBL = userNoteBL;
        }

        [HttpGet, Route("all")]
        public IEnumerable<UserNoteDTO> GetAll()
        {
            return userNoteBL.GetAll();
        }

        [HttpGet, Route("all-my")]
        public IEnumerable<UserNoteDTO> GetAllMy()
        {
                return userNoteBL.GetForUser(User.Identity.GetUserId());
        }

        [HttpGet, Route("{noteId}")]
        public UserNoteDTO GetById(int noteId)
        {
            return userNoteBL.GetById(noteId);
        }

        [HttpPost, Route("add")]
        public int Add(NewUserNoteDTO newNote)
        {
            return userNoteBL.Add(newNote, User.Identity.GetUserId());
        }

        [HttpDelete, Authorize(Roles = "admin"), Route("remove/{noteId}")]
        public bool RemoveById(int noteId)
        {
            return userNoteBL.RemoveById(noteId);
        }
    }
}
