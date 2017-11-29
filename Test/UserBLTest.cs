namespace Test
{
    using BLL.BLs;
    using Core.DTOs.UserDTOs;
    using Core.DTOs.UserNoteDTOs;
    using DAL.Entities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Ploeh.AutoFixture;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [TestClass]
    public class UserBLTest : BaseBLLTestData
    {
        private UserBL target;

        protected override void CreateTarget()
        {
            target = new UserBL(factoryMock.Object, imapperMock.Object);
        }

        [TestInitialize]
        public void Setup()
        {
            Configure();
        }

        [TestMethod]
        public void GetAllUsers_Test()
        {
            // Arrange
            CreateTarget();
            var userList = objFactory.GetUserListAsync();
            var expected = realMapperMock.Map<List<UserEntity>, List<UserDTO>>(userList.Result);
            imapperMock.Setup(m => m.Map(It.IsAny<List<UserEntity>>(), It.IsAny<List<UserDTO>>())).Returns(expected);
            userRepoMock.Setup(x => x.GetAllAsync()).Returns(objFactory.GetUserListAsync());

            // Act
            var actual = target.GetAllAsync().Result;

            // Assert
            factoryMock.Verify(f => f.Create(), Times.Once);
            unitOfWorkMock.Verify(u => u.UserRepository, Times.Once);
            Assert.AreEqual(expected, actual);
        }
    }
}
