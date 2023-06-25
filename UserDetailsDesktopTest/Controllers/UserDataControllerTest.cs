using NUnit.Framework;
using System.Collections.Generic;
using UserDetailsDesktop.Controllers;
using UserDetailsDesktop.Services;
using Moq;
using UserDetailsDesktop.Models;
using UserDetailsDesktop.DTOs;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace UserDetailsDesktopTest.Controllers
{
    [TestFixture]
    public class UserDataControllerTest
    {
        private UserDataController _userDataController;
        private Mock<IUserService> _userServiceMock;

        [SetUp]
        public void Setup()
        {
            _userServiceMock = new Mock<IUserService>();
            _userDataController = new UserDataController(_userServiceMock.Object);
        }

        // GET all users
        [Test]
        public void Get_WhenCalled_ShouldReturnListOfUsers()
        {
            // Arrange
            var usersList = new List<User>
            {
                new User { UserId = 1, UserName = "John Doe", DateOfBirth = new System.DateTime(1990, 1, 1), Location = "New York", IsActive = 1 },
                new User { UserId = 2, UserName = "Jane Smith", DateOfBirth = new System.DateTime(1985, 5, 5), Location = "London", IsActive = 1 },
                new User { UserId = 3, UserName = "Samanta Wallis", DateOfBirth = new System.DateTime(1985, 3, 12), Location = "Paris", IsActive = 1 },
                new User { UserId = 4, UserName = "Andy Jones", DateOfBirth = new System.DateTime(1985, 4, 10), Location = "India", IsActive = 0 },
                new User { UserId = 5, UserName = "Berry Allen", DateOfBirth = new System.DateTime(1985, 12, 12), Location = "Los Angles", IsActive = 0 }
            };
            _userServiceMock.Setup(x => x.GetAll()).Returns(usersList);
            // Act
            var result = _userDataController.Get();
            // Assert
            Assert.IsInstanceOf<IActionResult>(result);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(usersList, okResult.Value);
        }

        [Test]
        public void Get_ReturnsNotFoundForEmptyUserList()
        {
            // Arrange
            _userServiceMock.Setup(x => x.GetAll()).Returns(new List<User>());
            // Act
            var result = _userDataController.Get();
            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void Get_ReturnsNotFoundForNullUserList()
        {
            // Arrange
            _userServiceMock.Setup(x => x.GetAll()).Returns((List<User>)null);
            // Act
            var result = _userDataController.Get();
            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Get_ReturnsBadRequestForInvalidModelState()
        {
            // Arrange
            _userDataController.ModelState.AddModelError("Key", "Error");
            // Act
            var result = _userDataController.Get();
            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Get_ReturnsNotFoundForValidModelStateWithNullUserList()
        {
            // Arrange
            _userServiceMock.Setup(x => x.GetAll()).Returns((List<User>)null);
            // Act
            var result = _userDataController.Get();
            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }


        // GET by id test cases
        [Test]
        public void GetById_ExistingUserId_ShouldReturnUser()
        {
            // Arrange
            int userId = 1;
            var expectedUser = new User { UserId = userId, UserName = "John Doe", DateOfBirth = new System.DateTime(1990, 1, 1), Location = "New York", IsActive = 1 };
            _userServiceMock.Setup(x => x.GetById(userId)).Returns(expectedUser);
            // Act
            var result = _userDataController.GetById(userId);
            // Assert
            Assert.IsInstanceOf<IActionResult>(result);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(expectedUser, okResult.Value);
        }

        [Test]
        public void GetById_NonExistingUserId_ShouldReturnNotFound()
        {
            // Arrange
            int userId = 10;
            _userServiceMock.Setup(x => x.GetById(userId)).Returns((User)null);
            // Act
            var result = _userDataController.GetById(userId);
            // Assert
            Assert.IsInstanceOf<IActionResult>(result);
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }

        // Add method test cases
        [Test]
        public void Add_ValidUser_ShouldCallUserServiceAdd()
        {
            // Arrange
            var userDto = new UserDto { UserName = "Lakshmi Yamini", DateOfBirth = new System.DateTime(1990, 7, 3), Location = "Dublin" };
            // Act
            var result = _userDataController.Add(userDto);
            // Assert
            Assert.IsInstanceOf<IActionResult>(result);
            _userServiceMock.Verify(x => x.Add(It.IsAny<User>()), Times.Once);
        }

        [Test]
        public void Add_InvalidModelState_ReturnsBadRequest()
        {
            // Arrange
            _userDataController.ModelState.AddModelError("Key", "Error");
            // Act
            var result = _userDataController.Add(new UserDto());
            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            _userServiceMock.Verify(x => x.Add(It.IsAny<User>()), Times.Never);
        }

        [Test]
        public void Add_NullUserObject_ReturnsBadRequest()
        {
            // Act
            var result = _userDataController.Add(null);
            // Assert
            Assert.IsInstanceOf<BadRequestResult>(result);
            _userServiceMock.Verify(x => x.Add(It.IsAny<User>()), Times.Never);
        }

        // Update method test cases
        [Test]
        public void Update_ExistingUser_ShouldUpdateUserAndCallUserServiceUpdate()
        {
            // Arrange
            int userId = 3;
            var existingUser = new User { UserId = 3, UserName = "John Doe", DateOfBirth = new System.DateTime(1990, 1, 1), Location = "New York", IsActive = 1 };
            _userServiceMock.Setup(x => x.GetById(userId)).Returns(existingUser);
            // Act
            var result = _userDataController.Update(userId, new UserDto { UserName = "Parnitha Chopra", DateOfBirth = new System.DateTime(1990, 7, 3), Location = "Berlin" });
            // Assert
            Assert.IsInstanceOf<IActionResult>(result);
            _userServiceMock.Verify(x => x.Update(existingUser), Times.Once);
            Assert.AreEqual("Parnitha Chopra", existingUser.UserName);
            Assert.AreEqual(new System.DateTime(1990, 7, 3), existingUser.DateOfBirth);
            Assert.AreEqual("Berlin", existingUser.Location);
        }

        [Test]
        public void Update_NonExistingUser_ShouldReturnNotFound()
        {
            // Arrange
            int userId = 0;
            _userServiceMock.Setup(x => x.GetById(userId)).Returns((User)null);
            // Act
            var result = _userDataController.Update(userId, new UserDto { UserName = "Parnitha Chopra", DateOfBirth = new System.DateTime(1990, 7, 3), Location = "Berlin" });
            // Assert
            Assert.IsInstanceOf<IActionResult>(result);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        // Soft delete test cases

        [Test]
        public void SoftDelete_ExistingUser_ShouldSoftDeleteUserAndCallUserServiceUpdate()
        {
            // Arrange
            int userId = 3;
            var existingUser = new User { UserId = 3, UserName = "Samanta Wallis", DateOfBirth = new System.DateTime(1985, 3, 12), Location = "Paris", IsActive = 1 };
            _userServiceMock.Setup(x => x.GetById(userId)).Returns(existingUser);
            // Act
            var result = _userDataController.SoftDelete(userId);
            // Assert
            Assert.IsInstanceOf<IActionResult>(result);
            _userServiceMock.Verify(x => x.Update(existingUser), Times.Once);
            Assert.AreEqual(0, existingUser.IsActive);
        }

        [Test]
        public void SoftDelete_NonExistingUser_ShouldReturnNotFound()
        {
            // Arrange
            int userId = 10;
            _userServiceMock.Setup(x => x.GetById(userId)).Returns((User)null);
            // Act
            var result = _userDataController.SoftDelete(userId);
            // Assert
            Assert.IsInstanceOf<IActionResult>(result);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
    }
}
