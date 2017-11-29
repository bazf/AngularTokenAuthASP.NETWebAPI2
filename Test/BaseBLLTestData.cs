namespace Test
{
    using BLL.Mapping;
    using DAL.Entities;
    using DAL.Interfaces;
    using Moq;

    public abstract class BaseBLLTestData
    {
        protected Mock<IUnitOfWorkFactory> factoryMock;
        protected Mock<IUnitOfWork> unitOfWorkMock;
        protected Mock<IGenericRepository<UserNoteEntity>> userNoteRepoMock;
       
        protected Mock<IMapper> imapperMock;
        protected Mapper realMapperMock;
        protected ObjectFactory objFactory;

        protected void Configure()
        {
            factoryMock = new Mock<IUnitOfWorkFactory>();
            unitOfWorkMock = new Mock<IUnitOfWork>();
            userNoteRepoMock = new Mock<IGenericRepository<UserNoteEntity>>();

            imapperMock = new Mock<IMapper>();
            realMapperMock = new Mapper();

            factoryMock.Setup(x => x.Create()).Returns(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(un => un.UserNoteRepository).Returns(userNoteRepoMock.Object);

            objFactory = new ObjectFactory();
        }

        protected abstract void CreateTarget();
    }
}
