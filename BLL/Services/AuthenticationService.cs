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
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AuthenticationService : IAuthenticationService, IDisposable
    {
        private DevComDbContext ctx;

        private UserManager<UserEntity> userManager;

        public AuthenticationService()
        {
            ctx = new DevComDbContext();
            userManager = new UserManager<UserEntity>(new UserStore<UserEntity>(ctx));
        }

        public async Task<bool> RegisterDefaultUsers()
        {
            UserRegisterDTO user = new UserRegisterDTO()
            {
                UserName = "administrator",
                Password = "administrator",
                ConfirmPassword = "administrator"
            };

            var result = await RegisterUser(user, "admin");

            return result.Succeeded;
        }

        public async Task<IdentityResult> RegisterUser(UserRegisterDTO userModel, string role = "user")
        {
            UserEntity user = new UserEntity()
            {
                UserName = userModel.UserName,
            };

            var result = await userManager.CreateAsync(user, userModel.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRolesAsync(user.Id, role);
            }

            return result;
        }

        public async Task<UserEntity> FindUser(string userName, string password)
        {
            UserEntity user = await userManager.FindAsync(userName, password);

            return user;
        }

        public async Task<IEnumerable<string>> GetAllRoles(string userId)
        {
            var listRoles = await userManager.GetRolesAsync(userId);

            return listRoles;
        }

        public async Task<string> GetAllRolesJson(string userId)
        {
            var listRoles = await userManager.GetRolesAsync(userId);
            var rolesString = JsonConvert.SerializeObject(listRoles);

            return rolesString;
        }

        public void Dispose()
        {
            ctx.Dispose();
            userManager.Dispose();
        }
    }
}
