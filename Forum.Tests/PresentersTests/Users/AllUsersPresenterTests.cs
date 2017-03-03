using Forum.Data;
using Forum.MVP.Presenters.UserPresenters;
using Forum.MVP.Views.UserModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using WebFormsMvp;

namespace Forum.Tests.PresentersTests.Users
{
    [TestFixture]
    public class AllUsersPresenterTests
    {
        [Test]
        public void AllUsersPresenter_ShouldLoadUsersCorrectly()
        {
            // Arrange
            var view = new Mock<IView<AllUsersViewModel>>();
            view.SetupAllProperties();
            var usersData = new Mock<IUsersData>();
            var users = new List<AspNetUser>()
            {
                new AspNetUser() { Id=1 },
                new AspNetUser() { Id=2 }
            };

            usersData.Setup(u => u.UsersRepository.GetAllUsers()).Returns(users.AsQueryable);

            var presenter = new AllUsersPresenter(view.Object, usersData.Object);

            // Act
            view.Raise(v => v.Load += null, view.Object, new EventArgs());

            // Assert
            Assert.AreEqual(users, view.Object.Model.Users);
        }
    }
}
