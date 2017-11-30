namespace BLL.BLs
{
    using System.Collections.Generic;
    using BLL.Interfaces.IBLs;
    using Core.DTOs.UserDTOs;
    using DAL.Interfaces;
    using System.Threading.Tasks;
    using BLL.Mapping;
    using System;

    public class UserBL : BaseBL, IUserBL
    {
        private readonly IMapper mapper;

        public UserBL(IUnitOfWorkFactory factory, IMapper mapper)
            : base(factory)
        {
            this.mapper = mapper;
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
