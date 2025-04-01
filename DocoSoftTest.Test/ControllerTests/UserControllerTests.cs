using DocoSoftTest.Api.Controllers;
using DocoSoftTest.Application.Interfaces;
using DocoSoftTest.Domain.Entities;
using DocoSoftTest.Test.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DocoSoftTest.Test.IntegrationTests
{
    [TestClass]
    public class UserControllerTests
    {
        private readonly UserController _controller;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public UserControllerTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _controller = new UserController(_mockUnitOfWork.Object);
        }

        [TestMethod]
        public async Task GetAll_ShouldReturnSuccess()
        {
            // Arrange
            var users = new List<User> { new User { UserId = 1, FirstName = "Terry", LastName = "Delahunt", Email = "working@ho.me", PhoneNumber = "12345678" } };
            _mockUnitOfWork.Setup(u => u.Users.GetAllAsync()).ReturnsAsync(users);

            // Act
            var result = await _controller.GetAll();

            // Assert
            Assert.IsTrue(result.Success);
            var usersType = users.GetType();
            var resultType = result.Result.GetType();
            CollectionAssert.AreEqual(users, result.Result);
        }

        [TestMethod]
        public async Task GetById_ShouldReturnSuccess()
        {
            // Arrange
            var user = new User { UserId = 1, FirstName = "Terry", LastName = "Delahunt", Email = "working@ho.me", PhoneNumber = "12345678" };
            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(1)).ReturnsAsync(user);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual(user, result.Result);
        }

        [TestMethod]
        public async Task Add_ShouldReturnSuccess()
        {
            // Arrange
            var user = new User { UserId = 1, FirstName = "Terry", LastName = "Delahunt", Email = "working@ho.me", PhoneNumber = "12345678" };
            _mockUnitOfWork.Setup(u => u.Users.AddAsync(user)).ReturnsAsync("User added");

            // Act
            var result = await _controller.Add(user);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("User added", result.Result);
        }

        [TestMethod]
        public async Task Update_ShouldReturnSuccess()
        {
            // Arrange
            var user = new User { UserId = 1, FirstName = "Terry", LastName = "Delahunt", Email = "working@ho.me", PhoneNumber = "12345678" };
            _mockUnitOfWork.Setup(u => u.Users.UpdateAsync(user)).ReturnsAsync("User updated");

            // Act
            var result = await _controller.Update(user);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("User updated", result.Result);
        }

        [TestMethod]
        public async Task Delete_ShouldReturnSuccess()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Users.DeleteAsync(1)).ReturnsAsync("User deleted");

            // Act
            var result = await _controller.Delete(1);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("User deleted", result.Result);
        }

        [TestMethod]
        public async Task GetAll_ShouldHandleSqlException()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Users.GetAllAsync()).ThrowsAsync(TestConstants.GetSqlException());

            // Act
            var result = await _controller.GetAll();

            // Assert
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Result);
        }

        [TestMethod]
        public async Task GetById_ShouldHandleSqlException()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(1)).ThrowsAsync(TestConstants.GetSqlException());

            // Act
            var result = await _controller.GetById(1);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Result);
        }

        [TestMethod]
        public async Task Add_ShouldHandleSqlException()
        {
            // Arrange
            var user = new User { UserId = 1, FirstName = "Terry", LastName = "Delahunt", Email = "working@ho.me", PhoneNumber = "12345678" };
            _mockUnitOfWork.Setup(u => u.Users.AddAsync(user)).ThrowsAsync(TestConstants.GetSqlException());

            // Act
            var result = await _controller.Add(user);

            // Assert
            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public async Task Update_ShouldHandleSqlException()
        {
            // Arrange
            var user = new User { UserId = 1, FirstName = "Terry", LastName = "Delahunt", Email = "working@ho.me", PhoneNumber = "12345678" };
            _mockUnitOfWork.Setup(u => u.Users.UpdateAsync(user)).ThrowsAsync(TestConstants.GetSqlException());

            // Act
            var result = await _controller.Update(user);

            // Assert
            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public async Task Delete_ShouldHandleSqlException()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Users.DeleteAsync(1)).ThrowsAsync(TestConstants.GetSqlException());

            // Act
            var result = await _controller.Delete(1);

            // Assert
            Assert.IsFalse(result.Success);
        }
    }
}
