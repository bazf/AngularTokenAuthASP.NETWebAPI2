namespace BLL.Interfaces.IServices
{
    using System.Threading.Tasks;
    using Core.DTOs.UserDTOs;
    using DAL.Entities;
    using Microsoft.AspNet.Identity;
    using System.Collections.Generic;

    public interface IAuthenticationService
    {
        void Dispose();

        Task<UserEntity> FindUser(string userName, string password);

        Task<IEnumerable<string>> GetAllRoles(string userId);

        Task<string> GetAllRolesJson(string userId);

        Task<IdentityResult> RegisterUser(UserRegisterDTO userModel);
    }
}
