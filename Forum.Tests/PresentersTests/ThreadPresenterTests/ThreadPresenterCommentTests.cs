using Forum.Data;
using Forum.Data.Repositories;
using Forum.Presenters;
using Forum.Views;
using Forum.Views.Events;
using Moq;
using NUnit.Framework;
using System;
using System.Web;

namespace Forum.Tests.PresentersTests.ThreadPresenterTests
{
    [TestFixture]
    public class ThreadPresenterCommentTests
    {
        const string Above2500CharsContent = "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";

        [TestCase("TestComment With 51 Characters...sdfsdfsdf asd qw a")]
        [TestCase("ZxYhj 13 01 xasJgasd asd sads ds daeqd as dqw d asd s")]
        public void ThreadPresenter_Comment_ShouldCreateCommentsCorrectly(string testContent)
        {
            var view = new Mock<IThreadView>();
            view.SetupAllProperties();
            var forumData = new Mock<IForumData>();
            var commentsRepository = new Mock<ICommentsRepository>();

            forumData.Setup(d => d.CommentsRepository).Returns(commentsRepository.Object);

            var presenter = new ThreadPresenter(view.Object, forumData.Object);

            view.Raise(v => v.Comment += null, view.Object, new ReplyEventArgs(1, 1, testContent));

            commentsRepository.Verify(r => r.CreateComment(It.Is<Comment>(c => c.Contents == testContent)));
        }

        [Test]
        public void ThreadPresenter_Comment_ShouldReturnLogInMessageWhenThereIsNoUser()
        {
            var view = new Mock<IThreadView>();
            view.SetupAllProperties();
            var forumData = new Mock<IForumData>();
            var commentsRepository = new Mock<ICommentsRepository>();

            forumData.Setup(d => d.CommentsRepository).Returns(commentsRepository.Object);

            var presenter = new ThreadPresenter(view.Object, forumData.Object);

            var testContent = "TestComment With 51 Characters...sdfsdfsdf asd qw a";
            view.Raise(v => v.Comment += null, view.Object, new ReplyEventArgs(1, 0, testContent));

            StringAssert.Contains("Please, log in!", view.Object.Model.Error);
        }

        [TestCase("ShortOne")]
        [TestCase(Above2500CharsContent)]
        public void ThreadPresenter_Comment_ShouldReturnMessageWhenContentIsOutOfRange(string testContent)
        {
            var view = new Mock<IThreadView>();
            view.SetupAllProperties();
            var forumData = new Mock<IForumData>();
            var commentsRepository = new Mock<ICommentsRepository>();

            forumData.Setup(d => d.CommentsRepository).Returns(commentsRepository.Object);

            var presenter = new ThreadPresenter(view.Object, forumData.Object);

            view.Raise(v => v.Comment += null, view.Object, new ReplyEventArgs(1, 1, testContent));

            StringAssert.Contains("Content must be between", view.Object.Model.Error);
        }

        [Test]
        public void ThreadPresenter_Comment_ShouldTrimContentCorrectly()
        {
            var view = new Mock<IThreadView>();
            view.SetupAllProperties();
            var forumData = new Mock<IForumData>();
            var commentsRepository = new Mock<ICommentsRepository>();

            forumData.Setup(d => d.CommentsRepository).Returns(commentsRepository.Object);

            var presenter = new ThreadPresenter(view.Object, forumData.Object);

            var expectedContent = "TestContent Should be at least 50 characters long!!";
            var testContent = "  TestContent Should be at least 50 characters long!!    ";

            view.Raise(v => v.Comment += null, view.Object, new ReplyEventArgs(1, 1, testContent));

            commentsRepository.Verify(r => r.CreateComment(It.Is<Comment>(c => c.Contents == expectedContent)));
        }

        [Test]
        public void ThreadPresenter_Comment_ShouldSetAnswerIdCorrectly()
        {
            var view = new Mock<IThreadView>();
            view.SetupAllProperties();
            var forumData = new Mock<IForumData>();
            var commentsRepository = new Mock<ICommentsRepository>();

            forumData.Setup(d => d.CommentsRepository).Returns(commentsRepository.Object);

            var presenter = new ThreadPresenter(view.Object, forumData.Object);

            var testContent = "TestContent Should be at least 50 characters long!!";

            view.Raise(v => v.Comment += null, view.Object, new ReplyEventArgs(7, 1, testContent));

            commentsRepository.Verify(r => r.CreateComment(It.Is<Comment>(c => c.AnswerId == 7)));
        }

        [Test]
        public void ThreadPresenter_Comment_ShouldSetIsVisibleCorrectly()
        {
            var view = new Mock<IThreadView>();
            view.SetupAllProperties();
            var forumData = new Mock<IForumData>();
            var commentsRepository = new Mock<ICommentsRepository>();

            forumData.Setup(d => d.CommentsRepository).Returns(commentsRepository.Object);

            var presenter = new ThreadPresenter(view.Object, forumData.Object);

            var testContent = "TestContent Should be at least 50 characters long!!";

            view.Raise(v => v.Comment += null, view.Object, new ReplyEventArgs(7, 1, testContent));

            commentsRepository.Verify(r => r.CreateComment(It.Is<Comment>(c => c.IsVisible == true)));
        }

        [Test]
        public void ThreadPresenter_Comment_ShouldThrowWhenThereIsNotConnectionTODb()
        {
            var view = new Mock<IThreadView>();
            view.SetupAllProperties();
            var forumData = new Mock<IForumData>();
            var commentsRepository = new Mock<ICommentsRepository>();

            forumData.Setup(d => d.CommentsRepository).Returns(commentsRepository.Object);
            commentsRepository.Setup(c => c.CreateComment(It.IsAny<Comment>())).Throws(new Exception());

            var presenter = new ThreadPresenter(view.Object, forumData.Object);

            var testContent = "TestContent Should be at least 50 characters long!!";

            Assert.Throws<HttpException>(() => view.Raise(v => v.Comment += null, view.Object, new ReplyEventArgs(1, 1, testContent)));
        }
    }
}
