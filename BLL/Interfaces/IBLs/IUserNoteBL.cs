namespace BLL.Interfaces.IBLs
{
    using Core.DTOs.UserNoteDTOs;
    using System.Collections.Generic;

    public interface IUserNoteBL
    {
        IEnumerable<UserNoteDTO> GetAll();

        IEnumerable<UserNoteDTO> GetForUser(string userId);

        int Add(NewUserNoteDTO newNote, string userId);

        UserNoteDTO GetById(int noteId);

        bool RemoveById(int noteId);
    }
}
