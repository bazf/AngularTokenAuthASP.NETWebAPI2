namespace BLL.Interfaces.IServices
{
    using System.Threading.Tasks;
    using Core.DTOs.UserDTOs;
    using DAL.Entities;
    using Microsoft.AspNet.Identity;
    using System.Collections.Generic;
    using System.Security.Claims;

    public interface IAuthenticationService
    {
        void Dispose();

        Task<UserEntity> FindUser(string userName, string password);

        Task<bool> RegisterDefaultUsers();

        Task<IEnumerable<string>> GetAllRoles(string userId);

        Task<ClaimsIdentity> CreateIdentity(UserEntity user, string authenticationType);

        Task<string> GetAllRolesJson(string userId);

        Task<IdentityResult> RegisterUser(UserRegisterDTO userModel, string role = "user");
    }
}
