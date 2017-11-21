namespace BLL.Interfaces.IBLs
{
    using Core.DTOs.UserDTOs;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserBL
    {
        Task<List<UserDTO>> GetAllAsync();
    }
}
