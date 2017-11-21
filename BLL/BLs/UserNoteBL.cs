namespace BLL.BLs
{
    using BLL.Interfaces.IBLs;
    using BLL.Mapping;
    using Core.DTOs.UserNoteDTOs;
    using DAL.Entities;
    using DAL.Interfaces;
    using System.Linq;
    using System;
    using System.Collections.Generic;

    public class UserNoteBL : BaseBL, IUserNoteBL
    {
        private readonly IMapper mapper;

        public UserNoteBL(IUnitOfWorkFactory factory, IMapper mapper)
            : base(factory)
        {
            this.mapper = mapper;
        }

        public IEnumerable<UserNoteDTO> GetAll()
        {
            try
            {
                return UseDb(x =>
                {
                    return mapper.Map(x.UserNoteRepository.GetAll(), new List<UserNoteDTO>());
                });
            }
            catch (Exception ex)
            {
                return new List<UserNoteDTO>();
            }
        }

        public IEnumerable<UserNoteDTO> GetForUser(string userId)
        {
            try
            {
                return UseDb(x =>
                {
                    return mapper.Map(x.UserNoteRepository.Query().Where(n => n.UserId == userId), new List<UserNoteDTO>());
                });
            }
            catch (Exception ex)
            {
                return new List<UserNoteDTO>();
            }
        }

        public bool Add(NewUserNoteDTO newNote, string userId)
        {
            try
            {
                return UseDb(x =>
                {
                    var user = x.UserRepository.GetById(userId);
                    user.Notes.Add(mapper.Map(newNote, new UserNoteEntity()));
                    x.Save();
                    return true;
                });
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public UserNoteDTO GetById(int noteId)
        {
            try
            {
                return UseDb(x =>
                {
                    return mapper.Map(x.UserNoteRepository.GetById(noteId), new UserNoteDTO());
                });
            }
            catch (Exception ex)
            {
                return new UserNoteDTO();
            }
        }

        public bool RemoveById(int noteId)
        {
            try
            {
                return UseDb(x =>
                {
                    x.UserNoteRepository.Delete(x.UserNoteRepository.GetById(noteId));
                    x.Save();
                    return true;
                });
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
