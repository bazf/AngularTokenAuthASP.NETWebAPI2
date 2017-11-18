namespace BLL.Interfaces.IBLs
{
    using Core.DTOs.UserDTOs;
    using System.Collections.Generic;

    public interface IUserBL
    {
        IEnumerable<UserDTO> GetAll();
    }
}
