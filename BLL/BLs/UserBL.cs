namespace BLL.BLs
{
    using BLL.Interfaces;
    using DAL.Interfaces;

    public class UserBL : BaseBL, IUserBL
    {
        private readonly IMapper mapper;

        public UserBL(IUnitOfWorkFactory factory, IMapper mapper)
            : base(factory)
        {
            this.mapper = mapper;
        }

    }
}
