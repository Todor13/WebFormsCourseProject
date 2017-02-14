using Forum.Data;
using Forum.Presenters;
using Forum.Views;
using Forum.Views.Events;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using Forum.Data.Repositories;

namespace Forum.Tests.PresentersTests
{
    [TestFixture]
    public class CreateThreadPresenterTests
    {
        [Test]
        public void CreateThreadPresenter_ShoudPopulateSectionsCorrectly()
        {
            var view = new Mock<ICreateThreadView>();
            view.SetupAllProperties();
            var forumData = new Mock<IForumData>();

            var sections = new List<Section>()
            {
                new Section() { Name = "Important", Id = 1 },
                new Section() { Name = "Interests", Id = 2 }
            };

            var expected = new List<string>()
            {
                "Important",
                "Interests"
            };

            forumData.Setup(x => x.SectionsRepository.GetAllSections()).Returns(sections.AsQueryable);
            var presenter = new CreateThreadPresenter(view.Object, forumData.Object);

            view.Raise(v => v.Load += null, view.Object, new EventArgs());

            Assert.AreEqual(expected, view.Object.Model.Sections);
        }

        [Test]
        public void CreateThreadPresenter_ShouldCreateThreadCorrectly()
        {
            var view = new Mock<ICreateThreadView>();
            view.SetupAllProperties();
            var httpContex = new Mock<HttpContextBase>();
            var forumData = new Mock<IForumData>();
            var identity = new Mock<IIdentity>();
            var user = new Mock<IPrincipal>();
            var threadsRepository = new Mock<IThreadsRepository>();

            var section = new Section() { Name = "TestSection" };
            forumData.Setup(s => s.SectionsRepository.GetSectionByName(It.IsAny<string>())).Returns(section);
            httpContex.Setup(c => c.User).Returns(user.Object);
            user.Setup(u => u.Identity).Returns(identity.Object);
            forumData.Setup(f => f.ThreadsRepository).Returns(threadsRepository.Object);

            var presenter = new CreateThreadPresenter(view.Object, forumData.Object)
            {
                HttpContext = httpContex.Object
            };

            view.Raise(v => v.Create += null, view.Object, new CreateThreadEventArgs("TestTitle", "TestContent", "TestSection"));

            threadsRepository.Verify(t => t.CreateThread(It.Is<Thread>(x => x.Title == "TestTitle" && x.Contents == "TestContent" && x.Section == section)));
        }
    }
}
