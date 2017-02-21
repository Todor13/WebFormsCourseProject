using Forum.Data;
using Forum.MVP.Presenters;
using Forum.MVP.Views.ForumModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using WebFormsMvp;

namespace Forum.Tests.PresentersTests
{
    [TestFixture]
    public class HomePresenterTests
    {
        [Test]
        public void HomePresenter_ShouldLoadNewestThreads()
        {
            var view = new Mock<IView<HomeViewModel>>();
            view.SetupAllProperties();
            var forumData = new Mock<IForumData>();

            var thread1 = new Thread() { Id = 1, IsVisible = true, Published = new DateTime(2017, 01, 01), Section = new Section(), Answers = new List<Answer>() };
            var thread2 = new Thread() { Id = 2, IsVisible = true, Published = new DateTime(2017, 01, 03), Section = new Section(), Answers = new List<Answer>() };
            var thread3 = new Thread() { Id = 3, IsVisible = true, Published = new DateTime(2017, 01, 02), Section = new Section(), Answers = new List<Answer>() };


            var input = new List<Thread>()
            {
                thread1,
                thread2,
                thread3
            };

            forumData.Setup(f => f.ThreadsRepository.GetAllThreads()).Returns(input.AsQueryable);

            var expected = new List<Thread>()
            {
                thread2,
                thread3,
                thread1
            };

            var presenter = new HomePresenter(view.Object, forumData.Object);

            view.Raise(v => v.Load += null, new EventArgs());

            CollectionAssert.AreEqual(expected, view.Object.Model.NewestThreads);
        }

        [Test]
        public void HomePresenter_ShouldLoadMostDiscussedThreads()
        {
            var view = new Mock<IView<HomeViewModel>>();
            view.SetupAllProperties();
            var forumData = new Mock<IForumData>();

            var thread1 = new Thread() { Id = 1, IsVisible = true, Published = new DateTime(2017, 02, 03), Section = new Section(), Answers = new List<Answer>() };
            var thread2 = new Thread() { Id = 2, IsVisible = true, Published = new DateTime(2015, 01, 01), Section = new Section(), Answers = new List<Answer>() { new Answer(), new Answer() } };
            var thread3 = new Thread() { Id = 3, IsVisible = true, Published = new DateTime(2017, 05, 02), Section = new Section(), Answers = new List<Answer>() { new Answer() } };


            var input = new List<Thread>()
            {
                thread1,
                thread2,
                thread3
            };

            forumData.Setup(f => f.ThreadsRepository.GetAllThreads()).Returns(input.AsQueryable);

            var expected = new List<Thread>()
            {
                thread2,
                thread3,
                thread1
            };

            var presenter = new HomePresenter(view.Object, forumData.Object);

            view.Raise(v => v.Load += null, new EventArgs());

            CollectionAssert.AreEqual(expected, view.Object.Model.MostDiscussedThreads);
        }

        [Test]
        public void HomePresenter_ShouldLoadImportantThreadsRecentlyDiscussed()
        {
            var view = new Mock<IView<HomeViewModel>>();
            view.SetupAllProperties();
            var forumData = new Mock<IForumData>();

            var thread1 = new Thread() { Id = 1, IsVisible = true, Published = new DateTime(2017, 02, 03), Section = new Section(), Answers = new List<Answer>() };
            var thread2 = new Thread() { Id = 2, IsVisible = true, Published = new DateTime(2015, 01, 01), Section = new Section() { Name = "Important" }, Answers = new List<Answer>() { new Answer(), new Answer() } };
            var thread3 = new Thread() { Id = 3, IsVisible = true, Published = new DateTime(2017, 05, 02), Section = new Section() { Name = "Important" }, Answers = new List<Answer>() { new Answer() } };


            var input = new List<Thread>()
            {
                thread1,
                thread2,
                thread3
            };

            forumData.Setup(f => f.ThreadsRepository.GetAllThreads()).Returns(input.AsQueryable);

            var expected = new List<Thread>()
            {
                thread3,
                thread2
            };

            var presenter = new HomePresenter(view.Object, forumData.Object);

            view.Raise(v => v.Load += null, new EventArgs());

            CollectionAssert.AreEqual(expected, view.Object.Model.ImportantThreads);
        }

        [Test]
        public void HomePresenter_ShouldLoadImportantThreadsRecentlyDiscussed2()
        {
            var view = new Mock<IView<HomeViewModel>>();
            view.SetupAllProperties();
            var forumData = new Mock<IForumData>();

            var thread1 = new Thread() { Id = 1, IsVisible = true, Published = new DateTime(2017, 02, 03), Section = new Section(), Answers = new List<Answer>() };
            var thread2 = new Thread() { Id = 2, IsVisible = true, Published = new DateTime(2015, 01, 01), Section = new Section() { Name = "Important" }, Answers = new List<Answer>() { new Answer(), new Answer() { Published = new DateTime(2017, 02, 01)} } };
            var thread3 = new Thread() { Id = 3, IsVisible = true, Published = new DateTime(2017, 01, 02), Section = new Section() { Name = "Important" }, Answers = new List<Answer>() { new Answer() } };


            var input = new List<Thread>()
            {
                thread1,
                thread2,
                thread3
            };

            forumData.Setup(f => f.ThreadsRepository.GetAllThreads()).Returns(input.AsQueryable);

            var expected = new List<Thread>()
            {
                thread2,
                thread3
            };

            var presenter = new HomePresenter(view.Object, forumData.Object);

            view.Raise(v => v.Load += null, new EventArgs());

            CollectionAssert.AreEqual(expected, view.Object.Model.ImportantThreads);
        }
    }
}
