using Forum.Common;
using Forum.Data;
using Forum.Presenters;
using Forum.Views;
using Forum.Views.Events;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Forum.Tests.PresentersTests
{
    [TestFixture]
    public class SearchForumPresenterTests
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void SearchForumPresenter_ShouldReturnCorrectPageWithRightThreads(int page)
        {
            var view = new Mock<ISearchForumView>();
            view.SetupAllProperties();
            var forumData = new Mock<IForumData>();

            var threads = new List<Thread>()
            {
                new Thread() { Id = 1, IsVisible = true, Title = string.Empty, Contents = string.Empty },
                new Thread() { Id = 2, IsVisible = true, Title = string.Empty, Contents = string.Empty },
                new Thread() { Id = 3, IsVisible = true, Title = string.Empty, Contents = string.Empty },
                new Thread() { Id = 4, IsVisible = true, Title = string.Empty, Contents = string.Empty },
                new Thread() { Id = 5, IsVisible = true, Title = string.Empty, Contents = string.Empty },
                new Thread() { Id = 6, IsVisible = true, Title = string.Empty, Contents = string.Empty },
                new Thread() { Id = 7, IsVisible = true, Title = string.Empty, Contents = string.Empty }
            };

            forumData.Setup(d => d.ThreadsRepository.GetAllThreads()).Returns(threads.AsQueryable);

            var presenter = new SearchForumPresenter(view.Object, forumData.Object);

            view.Raise(v => v.SearchThreads += null, new SearchForumEventArgs(string.Empty, page));

            CollectionAssert.AreEqual(threads.Skip((page - 1) * GlobalConstants.PageSize).Take(GlobalConstants.PageSize), view.Object.Model.Threads);
        }

        [Test]
        public void SearchForumPresenter_ShouldReturnCorrectPageCountToView()
        {
            var view = new Mock<ISearchForumView>();
            view.SetupAllProperties();
            var forumData = new Mock<IForumData>();

            var presenter = new SearchForumPresenter(view.Object, forumData.Object);

            var exprectedThreadsCount = 3;
            var threads = new List<Thread>()
            {
                new Thread() { Id = 1, IsVisible = true, Title = string.Empty, Contents = string.Empty },
                new Thread() { Id = 2, IsVisible = true, Title = string.Empty, Contents = string.Empty },
                new Thread() { Id = 3, IsVisible = true, Title = string.Empty, Contents = string.Empty }
            };

            forumData.Setup(d => d.ThreadsRepository.GetAllThreads()).Returns(threads.AsQueryable);

            view.Raise(v => v.SearchThreads += null, new SearchForumEventArgs(string.Empty, 1));

            Assert.AreEqual(exprectedThreadsCount, view.Object.Model.PageCount);
        }

        [Test]
        public void SearchForumPresenter_ShouldReturnOnlyVisibleThreads()
        {
            var view = new Mock<ISearchForumView>();
            view.SetupAllProperties();
            var forumData = new Mock<IForumData>();

            var expectedVisibleThreadsCount = 3;
            var threads = new List<Thread>()
            {
                new Thread() { Id = 1, IsVisible = false, Title = string.Empty, Contents = string.Empty },
                new Thread() { Id = 2, IsVisible = true, Title = string.Empty, Contents = string.Empty },
                new Thread() { Id = 3, IsVisible = true, Title = string.Empty, Contents = string.Empty },
                new Thread() { Id = 4, IsVisible = false, Title = string.Empty, Contents = string.Empty },
                new Thread() { Id = 5, IsVisible = true, Title = string.Empty, Contents = string.Empty }
            };

            forumData.Setup(d => d.ThreadsRepository.GetAllThreads()).Returns(threads.AsQueryable);

            var presenter = new SearchForumPresenter(view.Object, forumData.Object);

            view.Raise(v => v.SearchThreads += null, new SearchForumEventArgs(string.Empty, 1));

            Assert.AreEqual(expectedVisibleThreadsCount, view.Object.Model.Threads.Count());
        }

        [TestCase("test")]
        [TestCase("Test")]
        [TestCase("aBcDeFgh")]
        public void SearchForumPresenter_ShouldReturnCorrectThreadsBySearchTerm(string searchTerm)
        {
            var view = new Mock<ISearchForumView>();
            view.SetupAllProperties();
            var forumData = new Mock<IForumData>();

            var expectedThreadsWithSearchTerm = 3;
            var threads = new List<Thread>()
            {
                new Thread() { Id = 1, IsVisible = true, Title = searchTerm, Contents = string.Empty },
                new Thread() { Id = 2, IsVisible = true, Title = string.Empty, Contents = searchTerm },
                new Thread() { Id = 3, IsVisible = true, Title = string.Empty, Contents = string.Empty },
                new Thread() { Id = 4, IsVisible = true, Title = searchTerm, Contents = string.Empty },
                new Thread() { Id = 5, IsVisible = true, Title = string.Empty, Contents = string.Empty }
            };

            forumData.Setup(d => d.ThreadsRepository.GetAllThreads()).Returns(threads.AsQueryable);

            var presenter = new SearchForumPresenter(view.Object, forumData.Object);

            view.Raise(v => v.SearchThreads += null, new SearchForumEventArgs(searchTerm, 1));

            Assert.AreEqual(expectedThreadsWithSearchTerm, view.Object.Model.Threads.Count());
            CollectionAssert.AreEqual(threads.Where(x => x.Contents == searchTerm || x.Title == searchTerm).ToList(), view.Object.Model.Threads);
        }
    }
}
