namespace BLL.BLs
{
    using BLL.Interfaces.IBLs;
    using BLL.Mapping;
    using DAL.Interfaces;

    public class UserNoteBL : BaseBL, IUserNoteBL
    {
        private readonly IMapper mapper;

        public UserNoteBL(IUnitOfWorkFactory factory, IMapper mapper)
            : base(factory)
        {
            this.mapper = mapper;
        }
    }
}
