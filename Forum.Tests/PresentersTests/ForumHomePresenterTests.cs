using NUnit.Framework;
using Moq;
using Forum.Views;
using System.Web;
using Forum.Data;
using Forum.Presenters;
using Forum.Views.Events;
using System.Collections.Generic;
using System.Linq;

namespace Forum.Tests.PresentersTests
{
    [TestFixture]
    public class ForumHomePresenterTests
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void ForumHomePresenter_ShouldPopulateCorrectPageWithRightThreads(int page)
        {
            var view = new Mock<IForumHomeView>();
            view.SetupAllProperties();
            var forumData = new Mock<IForumData>();

            var threads = new List<Thread>()
            {
                new Thread() { Id = 1, IsVisible = true },
                new Thread() { Id = 2, IsVisible = true },
                new Thread() { Id = 3, IsVisible = true },
                new Thread() { Id = 4, IsVisible = true },
                new Thread() { Id = 5, IsVisible = true },
                new Thread() { Id = 6, IsVisible = true },
                new Thread() { Id = 7, IsVisible = true }
            };

            forumData.Setup(d => d.ThreadsRepository.GetAllThreads()).Returns(threads.AsQueryable);

            var presenter = new ForumHomePresenter(view.Object, forumData.Object);

            view.Raise(v => v.LoadPage += null, view.Object, new ForumHomeEventArgs(page));

            Assert.AreEqual(threads.Skip((page-1) * Common.Constants.PageSize).Take(Common.Constants.PageSize), view.Object.Model.Threads);
        }

        [Test]
        public void ForumHomePresenter_ShouldReturnCorrectPageCountToView()
        {
            var view = new Mock<IForumHomeView>();
            view.SetupAllProperties();
            var forumData = new Mock<IForumData>();

            var presenter = new ForumHomePresenter(view.Object, forumData.Object);

            var exprectedThreadsCount = 3;
            var threads = new List<Thread>()
            {
                new Thread() { Id = 1, IsVisible = true },
                new Thread() { Id = 2, IsVisible = true },
                new Thread() { Id = 3, IsVisible = true }
            };

            forumData.Setup(d => d.ThreadsRepository.GetAllThreads()).Returns(threads.AsQueryable);

            view.Raise(v => v.LoadPage += null, view.Object, new ForumHomeEventArgs(1));

            Assert.AreEqual(exprectedThreadsCount, view.Object.Model.PageCount);
        }

        [Test]
        public void ForumHomePresenter_ShouldReturnOnlyVisibleThreads()
        {
            var view = new Mock<IForumHomeView>();
            view.SetupAllProperties();
            var forumData = new Mock<IForumData>();

            var expectedVisibleThreadsCount = 3;
            var threads = new List<Thread>()
            {
                new Thread() { Id = 1, IsVisible = false },
                new Thread() { Id = 2, IsVisible = true },
                new Thread() { Id = 3, IsVisible = true },
                new Thread() { Id = 4, IsVisible = false },
                new Thread() { Id = 5, IsVisible = true }
            };

            forumData.Setup(d => d.ThreadsRepository.GetAllThreads()).Returns(threads.AsQueryable);

            var presenter = new ForumHomePresenter(view.Object, forumData.Object);

            view.Raise(v => v.LoadPage += null, view.Object, new ForumHomeEventArgs(1));

            Assert.AreEqual(expectedVisibleThreadsCount, view.Object.Model.Threads.Count());
        }
    }
}
