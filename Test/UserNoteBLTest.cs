namespace Test
{
    using BLL.BLs;
    using Core.DTOs.UserNoteDTOs;
    using DAL.Entities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Ploeh.AutoFixture;
    using System.Collections.Generic;
    using System.Linq;

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
        public void RemoveById_Test()
        {
            // Arrange
            CreateTarget();
            userNoteRepoMock.Setup(a => a.GetById(It.IsAny<int>())).Returns(new UserNoteEntity());
            userNoteRepoMock.Setup(a => a.Delete(It.IsAny<UserNoteEntity>()));

            // Act
            target.RemoveById(It.IsAny<int>());

            // Assert
            factoryMock.Verify(f => f.Create(), Times.Once);
            userNoteRepoMock.Verify(f => f.GetById(It.IsAny<int>()), Times.Once);
            userNoteRepoMock.Verify(f => f.Delete(It.IsAny<UserNoteEntity>()), Times.Once);
            unitOfWorkMock.Verify(f => f.Save(), Times.Once);
        }

        [TestMethod]
        public void Add_Test()
        {
            // Arrange
            CreateTarget();
            UserNoteEntity expected = null;
            string userId = "id1";
            userNoteRepoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(expected);
            userRepoMock.Setup(x => x.GetById(It.IsAny<string>())).Returns(objFactory.GetUserList()[0]);

            // Act
            target.Add(new Fixture().Create<NewUserNoteDTO>(), userId);

            // Assert
            factoryMock.Verify(x => x.Create(), Times.Once);
            unitOfWorkMock.Verify(x => x.Save(), Times.Once);
        }

        [TestMethod]
        public void GetAll_Test()
        {
            // Arrange
            CreateTarget();
            var userNoteList = objFactory.GetUserNoteList();
            var expected = realMapperMock.Map<List<UserNoteEntity>, List<UserNoteDTO>>(userNoteList);
            imapperMock.Setup(m => m.Map(It.IsAny<IEnumerable<UserNoteEntity>>(), It.IsAny<List<UserNoteDTO>>())).Returns(expected);
            userNoteRepoMock.Setup(x => x.GetAll()).Returns(userNoteList);

            // Act
            var actual = target.GetAll();

            // Assert
            factoryMock.Verify(f => f.Create(), Times.Once);
            unitOfWorkMock.Verify(u => u.UserNoteRepository, Times.Once);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetForUser_Test()
        {
            // Arrange
            CreateTarget();
            string userId = "id1";
            var userNotes = objFactory.GetUserNoteList().Where(n => n.UserId == userId).AsQueryable();
            var expected = realMapperMock.Map<IQueryable<UserNoteEntity>, List<UserNoteDTO>>(userNotes);
            imapperMock.Setup(m => m.Map(It.IsAny<IQueryable<UserNoteEntity>>(), It.IsAny<List<UserNoteDTO>>())).Returns(expected);
            userNoteRepoMock.Setup(x => x.Query()).Returns(objFactory.GetUserNoteList().AsQueryable());

            // Act
            var actual = target.GetForUser(userId);

            // Assert
            factoryMock.Verify(f => f.Create(), Times.Once);
            Assert.AreEqual(expected, actual);
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
