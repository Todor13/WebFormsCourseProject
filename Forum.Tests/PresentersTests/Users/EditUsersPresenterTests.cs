using Forum.Data;
using Forum.MVP.Presenters.UserPresenters;
using Forum.MVP.Views.UserViews;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Forum.Tests.PresentersTests.Users
{
    [TestFixture]
    public class EditUsersPresenterTests
    {
        [Test]
        public void EditUsersPresenter_GetUser_ShouldLoadUserCorrectly()
        {
            var view = new Mock<IEditUserView>();
            view.SetupAllProperties();
            var usersData = new Mock<IUsersData>();
            var user = new AspNetUser() { Id = 1 };

            usersData.Setup(u => u.UsersRepository.GetUserById(It.IsAny<int>())).Returns(user);

            var presenter = new EditUserPresenter(view.Object, usersData.Object);

            view.Raise(v => v.GetUser += null, view.Object, new GetUserByIdEventArgs(1));

            Assert.AreEqual(user, view.Object.Model.User);
        }

        [Test]
        public void EditUsersPresenter_EditUser_ShouldEditRightUser()
        {
            var view = new Mock<IEditUserView>();
            view.SetupAllProperties();
            var usersData = new Mock<IUsersData>();
            var user = new AspNetUser() { Id = 1 };

            usersData.Setup(u => u.UsersRepository.GetUserById(It.IsAny<int>())).Returns(user);

            var presenter = new EditUserPresenter(view.Object, usersData.Object);

            view.Raise(v => v.GetUser += null, view.Object, new GetUserByIdEventArgs(1));
            view.Raise(v => v.UserEdit += null, view.Object, new EditUserEventArgs(1));

            usersData.Verify(x => x.UsersRepository.UpdateUser(It.Is<AspNetUser>(u => u.Id == 1)));
        }

        [Test]
        public void EditUsersPresenter_EditUser_ShouldEditFirstName()
        {
            var view = new Mock<IEditUserView>();
            view.SetupAllProperties();
            var usersData = new Mock<IUsersData>();
            var user = new AspNetUser() { Id = 1 };

            usersData.Setup(u => u.UsersRepository.GetUserById(It.IsAny<int>())).Returns(user);

            var presenter = new EditUserPresenter(view.Object, usersData.Object);

            view.Raise(v => v.GetUser += null, view.Object, new GetUserByIdEventArgs(1));
            var editedUserEventArgs = new EditUserEventArgs(1);
            editedUserEventArgs.FirstName = "Peter";
            view.Raise(v => v.UserEdit += null, view.Object, editedUserEventArgs);

            usersData.Verify(x => x.UsersRepository.UpdateUser(It.Is<AspNetUser>(u => u.FirstName == "Peter")));
        }

        [Test]
        public void EditUsersPresenter_EditUser_ShouldEditLastName()
        {
            var view = new Mock<IEditUserView>();
            view.SetupAllProperties();
            var usersData = new Mock<IUsersData>();
            var user = new AspNetUser() { Id = 1 };

            usersData.Setup(u => u.UsersRepository.GetUserById(It.IsAny<int>())).Returns(user);

            var presenter = new EditUserPresenter(view.Object, usersData.Object);

            view.Raise(v => v.GetUser += null, view.Object, new GetUserByIdEventArgs(1));
            var editedUserEventArgs = new EditUserEventArgs(1);
            editedUserEventArgs.LastName = "Ivanov";
            view.Raise(v => v.UserEdit += null, view.Object, editedUserEventArgs);

            usersData.Verify(x => x.UsersRepository.UpdateUser(It.Is<AspNetUser>(u => u.LastName == "Ivanov")));
        }

        [Test]
        public void EditUsersPresenter_EditUser_ShouldEditUserName()
        {
            var view = new Mock<IEditUserView>();
            view.SetupAllProperties();
            var usersData = new Mock<IUsersData>();
            var user = new AspNetUser() { Id = 1 };

            usersData.Setup(u => u.UsersRepository.GetUserById(It.IsAny<int>())).Returns(user);

            var presenter = new EditUserPresenter(view.Object, usersData.Object);

            view.Raise(v => v.GetUser += null, view.Object, new GetUserByIdEventArgs(1));
            var editedUserEventArgs = new EditUserEventArgs(1);
            editedUserEventArgs.UserName = "Asd";
            view.Raise(v => v.UserEdit += null, view.Object, editedUserEventArgs);

            usersData.Verify(x => x.UsersRepository.UpdateUser(It.Is<AspNetUser>(u => u.UserName == "Asd")));
        }

        [Test]
        public void EditUsersPresenter_EditUser_ShouldEditPhoneNumber()
        {
            var view = new Mock<IEditUserView>();
            view.SetupAllProperties();
            var usersData = new Mock<IUsersData>();
            var user = new AspNetUser() { Id = 1 };

            usersData.Setup(u => u.UsersRepository.GetUserById(It.IsAny<int>())).Returns(user);

            var presenter = new EditUserPresenter(view.Object, usersData.Object);

            view.Raise(v => v.GetUser += null, view.Object, new GetUserByIdEventArgs(1));
            var editedUserEventArgs = new EditUserEventArgs(1);
            editedUserEventArgs.PhoneNumber = "088";
            view.Raise(v => v.UserEdit += null, view.Object, editedUserEventArgs);

            usersData.Verify(x => x.UsersRepository.UpdateUser(It.Is<AspNetUser>(u => u.PhoneNumber == "088")));
        }

        [Test]
        public void EditUsersPresenter_EditUser_ShouldEditEmail()
        {
            var view = new Mock<IEditUserView>();
            view.SetupAllProperties();
            var usersData = new Mock<IUsersData>();
            var user = new AspNetUser() { Id = 1 };

            usersData.Setup(u => u.UsersRepository.GetUserById(It.IsAny<int>())).Returns(user);

            var presenter = new EditUserPresenter(view.Object, usersData.Object);

            view.Raise(v => v.GetUser += null, view.Object, new GetUserByIdEventArgs(1));
            var editedUserEventArgs = new EditUserEventArgs(1);
            editedUserEventArgs.Email = "yee@abv.bg";
            view.Raise(v => v.UserEdit += null, view.Object, editedUserEventArgs);

            usersData.Verify(x => x.UsersRepository.UpdateUser(It.Is<AspNetUser>(u => u.Email == "yee@abv.bg")));
        }

        [Test]
        public void EditUsersPresenter_EditUser_ShouldEditStreet()
        {
            var view = new Mock<IEditUserView>();
            view.SetupAllProperties();
            var usersData = new Mock<IUsersData>();
            var user = new AspNetUser() { Id = 1 };

            usersData.Setup(u => u.UsersRepository.GetUserById(It.IsAny<int>())).Returns(user);

            var presenter = new EditUserPresenter(view.Object, usersData.Object);

            view.Raise(v => v.GetUser += null, view.Object, new GetUserByIdEventArgs(1));
            var editedUserEventArgs = new EditUserEventArgs(1);
            editedUserEventArgs.Address = "Asd str";
            view.Raise(v => v.UserEdit += null, view.Object, editedUserEventArgs);

            usersData.Verify(x => x.UsersRepository.UpdateUser(It.Is<AspNetUser>(u => u.Address == "Asd str")));
        }

        [Test]
        public void EditUsersPresenter_EditUser_ShouldEditCity()
        {
            var view = new Mock<IEditUserView>();
            view.SetupAllProperties();
            var usersData = new Mock<IUsersData>();
            var user = new AspNetUser() { Id = 1 };

            usersData.Setup(u => u.UsersRepository.GetUserById(It.IsAny<int>())).Returns(user);

            var presenter = new EditUserPresenter(view.Object, usersData.Object);

            view.Raise(v => v.GetUser += null, view.Object, new GetUserByIdEventArgs(1));
            var editedUserEventArgs = new EditUserEventArgs(1);
            editedUserEventArgs.City = "Sofia";
            view.Raise(v => v.UserEdit += null, view.Object, editedUserEventArgs);

            usersData.Verify(x => x.UsersRepository.UpdateUser(It.Is<AspNetUser>(u => u.City == "Sofia")));
        }

        [Test]
        public void EditUsersPresenter_EditUser_ShouldEditState()
        {
            var view = new Mock<IEditUserView>();
            view.SetupAllProperties();
            var usersData = new Mock<IUsersData>();
            var user = new AspNetUser() { Id = 1 };

            usersData.Setup(u => u.UsersRepository.GetUserById(It.IsAny<int>())).Returns(user);

            var presenter = new EditUserPresenter(view.Object, usersData.Object);

            view.Raise(v => v.GetUser += null, view.Object, new GetUserByIdEventArgs(1));
            var editedUserEventArgs = new EditUserEventArgs(1);
            editedUserEventArgs.State = "state";
            view.Raise(v => v.UserEdit += null, view.Object, editedUserEventArgs);

            usersData.Verify(x => x.UsersRepository.UpdateUser(It.Is<AspNetUser>(u => u.State == "state")));
        }

        [Test]
        public void EditUsersPresenter_EditUser_ShouldEditPostalCode()
        {
            var view = new Mock<IEditUserView>();
            view.SetupAllProperties();
            var usersData = new Mock<IUsersData>();
            var user = new AspNetUser() { Id = 1 };

            usersData.Setup(u => u.UsersRepository.GetUserById(It.IsAny<int>())).Returns(user);

            var presenter = new EditUserPresenter(view.Object, usersData.Object);

            view.Raise(v => v.GetUser += null, view.Object, new GetUserByIdEventArgs(1));
            var editedUserEventArgs = new EditUserEventArgs(1);
            editedUserEventArgs.PostalCode = "1300";
            view.Raise(v => v.UserEdit += null, view.Object, editedUserEventArgs);

            usersData.Verify(x => x.UsersRepository.UpdateUser(It.Is<AspNetUser>(u => u.PostalCode == "1300")));
        }

        [Test]
        public void EditUsersPresenter_EditUser_ShouldThrowUserIsDifferent()
        {
            var view = new Mock<IEditUserView>();
            view.SetupAllProperties();
            var usersData = new Mock<IUsersData>();
            var user = new AspNetUser() { Id = 1 };

            usersData.Setup(u => u.UsersRepository.GetUserById(It.IsAny<int>())).Returns(user);

            var presenter = new EditUserPresenter(view.Object, usersData.Object);

            view.Raise(v => v.GetUser += null, view.Object, new GetUserByIdEventArgs(1));

            Assert.Throws<HttpException>(() => view.Raise(v => v.UserEdit += null, view.Object, new EditUserEventArgs(2)));
        }

        [Test]
        public void EditUsersPresenter_EditUser_ShouldThrowifUserIsNotLoad()
        {
            var view = new Mock<IEditUserView>();
            view.SetupAllProperties();
            var usersData = new Mock<IUsersData>();
            var user = new AspNetUser() { Id = 1 };

            usersData.Setup(u => u.UsersRepository.GetUserById(It.IsAny<int>())).Returns(user);

            var presenter = new EditUserPresenter(view.Object, usersData.Object);

            Assert.Throws<HttpException>(() => view.Raise(v => v.UserEdit += null, view.Object, new EditUserEventArgs(1)));
        }

        [Test]
        public void EditUsersPresenter_EditUser_ShouldThrowIfDbFail()
        {
            var view = new Mock<IEditUserView>();
            view.SetupAllProperties();
            var usersData = new Mock<IUsersData>();
            var user = new AspNetUser() { Id = 1 };

            usersData.Setup(u => u.UsersRepository.GetUserById(It.IsAny<int>())).Returns(user);
            usersData.Setup(u => u.UsersRepository.UpdateUser(It.IsAny<AspNetUser>())).Throws(new Exception());
            var presenter = new EditUserPresenter(view.Object, usersData.Object);

            view.Raise(v => v.GetUser += null, view.Object, new GetUserByIdEventArgs(1));

            Assert.Throws<HttpException>(() => view.Raise(v => v.UserEdit += null, view.Object, new EditUserEventArgs(1)));
        }
    }
}
