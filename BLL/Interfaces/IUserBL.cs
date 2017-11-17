namespace BLL.Interfaces
{
    using Core.DTOs.UserDTOs;
    using System.Collections.Generic;

    public interface IUserBL
    {
        IEnumerable<UserDTO> GetAll();
    }
}
