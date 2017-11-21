namespace BLL.BLs
{
    using System.Collections.Generic;
    using BLL.Interfaces.IBLs;
    using Core.DTOs.UserDTOs;
    using DAL.Interfaces;
    using System.Linq;
    using System.Threading.Tasks;
    using BLL.Mapping;
    using System;
    using BLL.Interfaces.IServices;

    public class UserBL : BaseBL, IUserBL
    {
        private readonly IMapper mapper;
        private IAuthenticationService authService;

        public UserBL(IUnitOfWorkFactory factory, IMapper mapper, IAuthenticationService authService)
            : base(factory)
        {
            this.mapper = mapper;
            this.authService = authService;
        }

        public async Task<List<UserDTO>> GetAllAsync()
        {
            try
            {
                return await UseDbAsync(async x =>
                 {
                     var dbUsers = await x.UserRepository.GetAllAsync();
                     return mapper.Map(dbUsers, new List<UserDTO>());

                 });
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
