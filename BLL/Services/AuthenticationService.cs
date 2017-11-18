namespace BLL.Services
{
    using BLL.Interfaces.IServices;
    using Core.DTOs.UserDTOs;
    using DAL;
    using DAL.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Newtonsoft.Json;
    using System;
    using System.Threading.Tasks;

    public class AuthenticationService : IAuthenticationService, IDisposable
    {
        private DevComDbContext _ctx;

        private UserManager<UserEntity> _userManager;

        public AuthenticationService()
        {
            _ctx = new DevComDbContext();
            _userManager = new UserManager<UserEntity>(new UserStore<UserEntity>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserRegisterDTO userModel)
        {
            UserEntity user = new UserEntity()
            {
                UserName = userModel.UserName
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<UserEntity> FindUser(string userName, string password)
        {
            UserEntity user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public async Task<string> GetAllRolesJson(string userId)
        {
            var listRoles = await _userManager.GetRolesAsync(userId);
            var rolesString = JsonConvert.SerializeObject(listRoles);

            return rolesString;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }
    }
}
