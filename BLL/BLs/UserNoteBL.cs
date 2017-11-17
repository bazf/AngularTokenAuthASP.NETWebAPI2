namespace BLL.BLs
{
    using BLL.Interfaces;
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
