namespace BLL.BLs
{
    using System.Collections.Generic;
    using BLL.Interfaces;
    using Core.DTOs.UserDTOs;
    using DAL.Interfaces;
    using BLL.Mapping;

    public class UserBL : BaseBL, IUserBL
    {
        private readonly IMapper mapper;

        public UserBL(IUnitOfWorkFactory factory, IMapper mapper)
            : base(factory)
        {
            this.mapper = mapper;
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return new List<UserDTO> { new UserDTO { UserName = "Mark" } };
        }
    }
}
