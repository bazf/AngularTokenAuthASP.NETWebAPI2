namespace Test
{
    using BLL.BLs;
    using Core.DTOs.UserNoteDTOs;
    using DAL.Entities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Ploeh.AutoFixture;

    [TestClass]
    public class UserNoteBLTest : BaseBLLTestData
    {
        private UserNoteBL target;

        protected override void CreateTarget()
        {
            target = new UserNoteBL(factoryMock.Object, imapperMock.Object);
        }

        [TestInitialize]

        public void Setup()
        {
            Configure();
        }

        [TestMethod]
        public void GetUserNoteById_Test()
        {
            // Arrange
            CreateTarget();
            var userNote = objFactory.GetUserNoteList()[0];
            var expected = realMapperMock.Map<UserNoteEntity, UserNoteDTO>(userNote);
            imapperMock.Setup(m => m.Map(It.IsAny<UserNoteEntity>(), It.IsAny<UserNoteDTO>())).Returns(expected);
            userNoteRepoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(userNote);

            // Act
            var actual = target.GetById(1);

            // Assert
            factoryMock.Verify(f => f.Create(), Times.Once);
            unitOfWorkMock.Verify(u => u.UserNoteRepository, Times.Once);
            Assert.AreEqual(expected, actual);
        }
    }
}
